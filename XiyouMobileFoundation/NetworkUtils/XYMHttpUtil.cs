/**
 * Copyright (C) 2015 Xiyou Mobile Application Lab.
 * 
 * XiyouMobileFoundation
 * 
 * XYMHttpUtil.cs
 * 
 * Created by Yuan Guozheng on 2015-5-5.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using XiyouMobileFoundation.Models;
using XiyouMobileFoundation.TextUtils;
using System.Diagnostics;
using System.IO;

namespace XiyouMobileFoundation.NetworkUtils
{
    /// <summary>
    /// HTTP请求工具类
    /// </summary>
    public class XYMHttpUtil
    {
        #region 成员变量

        public const String BOUNDARY = "----abcdefg";  // POST上传文件分隔符

        private const String RN = "\r\n";  // 空行字符

        private const String STRINGPARAM_FORMAT = "Content-Disposition: form-data; name=\"{0}\"";  // 文字参数格式

        private const String FILEPARMA_FORMAT = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"";  // 文件参数格式

        private const int BUFFER_SIZE = 1024;  // 默认缓冲区大小

        private XYMHttpRequestModel requestModel;  // 请求模型对象

        private XYMHttpResponseModel responseModel;  // 响应模型对象

        private HttpWebRequest request;  // 请求对象

        private HttpWebResponse response;  // 响应对象

        private Stream requestStream;  // 请求体

        private String cookieString;  // Cookie字符串

        private String mimeString;  // MIME字符串

        private String responseString;  // 响应字符串

        public delegate void ResponseHandler(XYMHttpResponseModel responseModel);  // 完成代理

        private static ResponseHandler OnGetResponse;  // 完成代理对象

        public event ResponseHandler Completed  // 完成事件
        {
            add
            {
                OnGetResponse += value;
            }
            remove
            {
                OnGetResponse -= value;
            }
        }

        #endregion

        /// <summary>
        /// 使用请求对象发送HTTP请求
        /// </summary>
        /// <param name="model">请求对象</param>
        public void DoRequestWithModel(XYMHttpRequestModel model)
        {
            requestModel = model;
            responseModel = new XYMHttpResponseModel();
            InitRequest();
            if (requestModel.Method == HttpMethod.POST)
            {
                ConstructPost();
            }
            ReceiveResponse();
        }

        /// <summary>
        /// 初始化HTTP请求
        /// </summary>
        private void InitRequest()
        {
            try
            {
                request = (HttpWebRequest)HttpWebRequest.CreateDefault(new Uri(requestModel.Url));
                request.Method = requestModel.Method.ToString();
                request.CachePolicy = requestModel.CachePolicy;
                request.Timeout = requestModel.Timeout;
                request.KeepAlive = requestModel.KeepAlive;
                request.ContentType = requestModel.ContentType;
                request.UserAgent = requestModel.UserAgent;
                AddHeaders(requestModel.Headers);
            }
            catch (Exception initRequsetExp)
            {
                Debug.WriteLine(initRequsetExp.StackTrace);
                responseModel.IsSuccess = false;
                OnGetResponse(responseModel);
            }
        }

        /// <summary>
        /// 添加请求头
        /// </summary>
        /// <param name="headers">请求头集合</param>
        private void AddHeaders(Dictionary<String, String> headers)
        {
            if (request != null && headers != null)
            {
                foreach (KeyValuePair<String, String> item in headers)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }
        }

        /// <summary>
        /// 接收响应
        /// </summary>
        private void ReceiveResponse()
        {
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception getResponseExp)
            {
                Debug.WriteLine(getResponseExp.StackTrace);
                responseModel.IsSuccess = false;
                OnGetResponse(responseModel);
            }
            if (response != null)
            {
                ConstructCallback();
            }
        }

        /// <summary>
        /// 构建回调对象
        /// </summary>
        private void ConstructCallback()
        {
            cookieString = response.GetResponseHeader("Set-Cookie");
            responseModel.Cookie = cookieString;
            mimeString = response.GetResponseHeader("Content-Type");
            responseModel.ContentType = mimeString;
            using (Stream responseStream = response.GetResponseStream())
            {
                try
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding(requestModel.Charset));
                    responseString = reader.ReadToEnd();
                    responseModel.ResponseHtml = responseString;
                }
                catch (Exception transferResponseEncodeExp)
                {
                    Debug.WriteLine(transferResponseEncodeExp.StackTrace);
                }
                responseModel.ResponseStream = responseStream;
                responseModel.IsSuccess = true;
                OnGetResponse(responseModel);
            }
        }

        /// <summary>
        /// 构建POST请求报文
        /// </summary>
        private void ConstructPost()
        {
            using (requestStream = request.GetRequestStream())
            {
                try
                {
                    BuildPostRequest();
                }
                catch (Exception buildRequestExp)
                {
                    Debug.WriteLine(buildRequestExp.StackTrace);
                    responseModel.IsSuccess = false;
                    OnGetResponse(responseModel);
                }
            }
        }

        #region 构建POST请求报文实现部分

        /// <summary>
        /// 构建POST请求
        /// </summary>
        private void BuildPostRequest()
        {
            if (!requestModel.IsFileReqeuset)
            {
                if (requestModel.UrlEncodedParams.Count == 0)
                {
                    return;
                }
                BuildUrlEncodedParams();
            }
            else
            {
                if (requestModel.UrlEncodedParams.Count != 0)
                {
                    BuildMultipartParams();
                }
                if (requestModel.PostFile.Count != 0)
                {
                    BuildFileBody();
                }
                if (requestModel.UrlEncodedParams.Count != 0 || requestModel.PostFile.Count != 0)
                {
                    BuildEndBoundary();
                }
            }
        }

        /// <summary>
        /// 构建仅含字符串参数的报文
        /// </summary>
        private void BuildUrlEncodedParams()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in requestModel.UrlEncodedParams)
            {
                string key = XYMTextEncoder.UrlEncode(item.Key, requestModel.Charset);
                string value = XYMTextEncoder.UrlEncode(item.Value, requestModel.Charset);
                builder.AppendFormat("{0}={1}&", key, value);
            }
            builder.Remove(builder.Length - 1, 1);
            WriteStringBytes(builder.ToString());
        }

        /// <summary>
        /// 构建Multipart形式字符串参数
        /// </summary>
        private void BuildMultipartParams()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in requestModel.UrlEncodedParams)
            {
                string key = XYMTextEncoder.UrlEncode(item.Key, requestModel.Charset);
                string value = XYMTextEncoder.UrlEncode(item.Value, requestModel.Charset);
                builder.Append("--");
                builder.AppendLine(BOUNDARY);
                builder.AppendLine(String.Format(STRINGPARAM_FORMAT, key));
                builder.AppendLine();
                builder.AppendLine(value);
                WriteStringBytes(builder.ToString());
            }
        }

        /// <summary>
        /// 构建文件流参数
        /// </summary>
        private void BuildFileBody()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in requestModel.PostFile)
            {
                builder.Clear();
                builder.Append("--");
                builder.AppendLine(BOUNDARY);
                builder.AppendLine(String.Format(FILEPARMA_FORMAT, item.Key, item.FileName));
                builder.AppendLine();
                WriteStringBytes(builder.ToString());
                WriteStreamBytes(File.Open(item.FileUri.AbsolutePath, FileMode.Open));
                WriteStringBytes(RN);
            }
        }

        /// <summary>
        /// 构建结束分隔符
        /// </summary>
        private void BuildEndBoundary()
        {
            WriteStringBytes("--");
            WriteStringBytes(BOUNDARY);
            WriteStringBytes("--");
        }

        /// <summary>
        /// 写入Byte流
        /// </summary>
        /// <param name="data"></param>
        private void WriteBytes(byte[] data)
        {
            if (requestStream == null || !requestStream.CanWrite)
            {
                return;
            }
            requestStream.Write(data, 0, data.Length);
        }

        /// <summary>
        /// 写入字符串Byte流
        /// </summary>
        /// <param name="str"></param>
        private void WriteStringBytes(string str)
        {
            byte[] data = Encoding.GetEncoding(requestModel.Charset).GetBytes(str);
            WriteBytes(data);
        }

        /// <summary>
        /// 写入文件流
        /// </summary>
        /// <param name="stream">文件流</param>
        private void WriteStreamBytes(Stream stream)
        {
            try
            {
                byte[] buffer = new byte[BUFFER_SIZE];
                int len = 0;
                while ((len = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    requestStream.Write(buffer, 0, len);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
            }
            finally
            {
                stream.Close();
            }
        }

        #endregion
    }
}
