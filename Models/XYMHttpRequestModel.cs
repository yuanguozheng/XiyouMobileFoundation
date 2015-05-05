/**
 * Copyright (C) 2015 Xiyou Mobile Application Lab.
 * 
 * XiyouMobileMVCLib
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

namespace XiyouMobileMVCLib.Models
{
    /// <summary>
    /// HTTP请求设置实体类
    /// </summary>
    public class XYMHttpRequestModel
    {
        private const int TIME_OUT = 30 * 1000;  // 默认30秒超时

        /// <summary>
        /// 构造函数，初始化默认值
        /// </summary>
        public XYMHttpRequestModel()
        {
            _Method = HttpMethod.GET;
            _CachePolicy = WebRequest.DefaultCachePolicy;
            _KeepAlive = true;
            _Timeout = TIME_OUT;
            _Headers = new Dictionary<string, string>();
        }

        /// <summary>
        /// 请求URL
        /// </summary>
        public String Url { get; set; }

        private HttpMethod _Method;

        /// <summary>
        /// 请求方法，支持GET、POST、PUT、DELETE、HEAD，默认GET
        /// </summary>
        public HttpMethod Method
        {
            get
            {
                return _Method;
            }
            set
            {
                if (value != _Method)
                {
                    _Method = value;
                }
            }
        }

        private RequestCachePolicy _CachePolicy;

        /// <summary>
        /// 缓存策略，默认DefaultCachePolicy
        /// </summary>
        public RequestCachePolicy CachePolicy
        {
            get
            {
                return _CachePolicy;
            }
            set
            {
                if (value != _CachePolicy)
                {
                    _CachePolicy = value;
                }
            }
        }

        private bool _KeepAlive;

        /// <summary>
        /// 保持连接，默认为true
        /// </summary>
        public bool KeepAlive
        {
            get
            {
                return _KeepAlive;
            }
            set
            {
                if (value != _KeepAlive)
                {
                    _KeepAlive = value;
                }
            }
        }

        private int _Timeout;

        /// <summary>
        /// 超时时长，默认30秒
        /// </summary>
        public int Timeout
        {
            get
            {
                return _Timeout;
            }
            set
            {
                if (value != _Timeout)
                {
                    _Timeout = value;
                }
            }
        }

        private Dictionary<String, String> _Headers;

        /// <summary>
        /// HTTP头元素集合
        /// </summary>
        public Dictionary<String, String> Headers
        {
            get
            {
                return _Headers;
            }
            set
            {
                if (value != _Headers)
                {
                    _Headers = value;
                }
            }
        }
    }

    /// <summary>
    /// HTTP请求方法枚举
    /// </summary>
    public enum HttpMethod
    {
        GET, POST, PUT, HEAD, DELETE,
    }
}
