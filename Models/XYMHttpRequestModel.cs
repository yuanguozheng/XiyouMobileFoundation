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
    public class XYMHttpRequestModel
    {
        public XYMHttpRequestModel()
        {
            _Method = HttpMethod.GET;
            _CachePolicy = WebRequest.DefaultCachePolicy;
            _KeepAlive = true;
            _Timeout = 30;
            _Headers = new Dictionary<string, string>();
        }

        public String Url { get; set; }

        private HttpMethod _Method;
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

    public enum HttpMethod
    {
        GET, POST, PUT, HEAD, DELETE,
    }
}
