/**
 * Copyright (C) 2015 Xiyou Mobile Application Lab.
 * 
 * XiyouMobileMVCLib
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
using XiyouMobileMVCLib.Models;

namespace XiyouMobileMVCLib.Utils
{
    /// <summary>
    /// HTTP请求工具类
    /// </summary>
    public class XYMHttpUtil
    {
        private static HttpWebRequest request;

        private delegate object ResponseHandler(object obj);

        public static void DoRequestWithModel(XYMHttpRequestModel model)
        {
            request = (HttpWebRequest)HttpWebRequest.CreateDefault(new Uri(model.Url));
            request.Method = model.Method.ToString();
            request.CachePolicy = model.CachePolicy;
            request.Timeout = model.Timeout;
            request.KeepAlive = model.KeepAlive;
            AddHeaders(model.Headers);
        }

        private static void AddHeaders(Dictionary<String, String> headers)
        {
            if (request != null && headers != null)
            {
                foreach (KeyValuePair<String, String> item in headers)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }
        }
    }
}
