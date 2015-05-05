/**
 * Copyright (C) 2015 Xiyou Mobile Application Lab.
 * 
 * XiyouMobileFoundation
 * 
 * XYMHttpResponseModel.cs
 * 
 * Created by Yuan Guozheng on 2015-5-6.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XiyouMobileFoundation.Models
{
    /// <summary>
    /// HTTP响应实体类
    /// </summary>
    public class XYMHttpResponseModel
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Cookie字符串
        /// </summary>
        public string Cookie { get; set; }

        /// <summary>
        /// MIME字符串
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// 响应字符串
        /// </summary>
        public string ResponseHtml { get; set; }

        /// <summary>
        /// 响应流
        /// </summary>
        public Stream ResponseStream { get; set; }
    }
}
