/**
 * Copyright (C) 2015 Xiyou Mobile Application Lab.
 * 
 * XiyouMobileFoundation
 * 
 * XYMWebApiUniResult.cs
 * 
 * Created by Yuan Guozheng on 2015-5-5.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Cache;
using System.Net;
using System.IO;

namespace XiyouMobileFoundation.Models
{
    /// <summary>
    /// HTTP请求设置实体类
    /// </summary>
    public class XYMHttpRequestModel
    {
        private const String CHARSET = "utf-8";  // 默认编码集

        private const int TIME_OUT = 30 * 1000;  // 默认30秒超时

        private const String BOUNDARY = "----abcdefg";  // POST上传文件分隔符

        private const String POST_CONTENT_TYPE = "application/x-www-form-urlencoded";  // 文本参数Content-Type

        private const String FILE_CONTENT_TYPE = "multipart/form-data";  // 文件参数Content-Type

        /// <summary>
        /// 构造函数，初始化默认值
        /// </summary>
        public XYMHttpRequestModel()
        {
            Url = null;
            Method = HttpMethod.GET;
            Charset = CHARSET;
            CachePolicy = WebRequest.DefaultCachePolicy;
            KeepAlive = true;
            Timeout = TIME_OUT;
            Headers = new Dictionary<string, string>();
            UrlEncodedParams = new Dictionary<string, string>();
            IsFileReqeuset = false;
            PostFile = null;
        }

        /// <summary>
        /// 请求URL
        /// </summary>
        public String Url { get; set; }

        /// <summary>
        /// 获取编码集，默认UTF-8
        /// </summary>
        public String Charset { get; set; }

        /// <summary>
        /// 请求方法，支持GET、POST、PUT、DELETE、HEAD，默认GET
        /// </summary>
        public HttpMethod Method { get; set; }

        /// <summary>
        /// 根据Method和请求参数获得ContentType
        /// </summary>
        public String ContentType
        {
            get
            {
                switch (Method)
                {
                    case HttpMethod.GET:
                        return null;
                    case HttpMethod.POST:
                        {
                            if (IsFileReqeuset)
                            {
                                return FILE_CONTENT_TYPE;
                            }
                            return POST_CONTENT_TYPE;
                        }
                    default:
                        return null;
                }
            }
        }

        /// <summary>
        /// 保持连接，默认为true
        /// </summary>
        public bool IsFileReqeuset { get; set; }

        /// <summary>
        /// 缓存策略，默认DefaultCachePolicy
        /// </summary>
        public RequestCachePolicy CachePolicy { get; set; }

        /// <summary>
        /// 保持连接，默认为true
        /// </summary>
        public bool KeepAlive { get; set; }

        /// <summary>
        /// 超时时长，默认30秒
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// HTTP头元素集合
        /// </summary>
        public Dictionary<String, String> Headers { get; set; }

        /// <summary>
        /// 字符串参数集合
        /// </summary>
        public Dictionary<String, String> UrlEncodedParams { get; set; }

        /// <summary>
        /// 要上传的文件
        /// </summary>
        public String PostFile { get; set; }
    }

    /// <summary>
    /// HTTP请求方法枚举
    /// </summary>
    public enum HttpMethod
    {
        GET, POST, PUT, HEAD, DELETE,
    }
}
