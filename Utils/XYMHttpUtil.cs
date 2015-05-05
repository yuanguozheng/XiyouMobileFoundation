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
using System.Diagnostics;
using System.IO;

namespace XiyouMobileFoundation.Utils
{
    /// <summary>
    /// HTTP请求工具类
    /// </summary>
    public class XYMHttpUtil
    {
        private const String RN = "\r\n";

        private const String STRINGPARAM_FORMAT = "Content-Disposition: form-data; name=\"%s\"";

        private const String FILEPARMA_FORMAT = "Content-Disposition: form-data; name=\"%s\"; filename=\"%s\"";

        private XYMHttpRequestModel requestModel;

        private HttpWebRequest request;

        private Stream requestStream;

        private delegate object ResponseHandler(object obj);

        public void DoRequestWithModel(XYMHttpRequestModel model)
        {
            requestModel = model;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.CreateDefault(new Uri(model.Url));
                request.Method = model.Method.ToString();
                request.CachePolicy = model.CachePolicy;
                request.Timeout = model.Timeout;
                request.KeepAlive = model.KeepAlive;
                request.ContentType = model.ContentType;
                AddHeaders(model.Headers);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
            }
            if (model.Method == HttpMethod.POST)
            {
                using (requestStream = request.GetRequestStream())
                {
                    BuildPostRequest();
                }
            }
        }

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

        private void BuildPostRequest()
        {
            if (!requestModel.IsFileReqeuset) 
            {
            }
        }
    }
}
