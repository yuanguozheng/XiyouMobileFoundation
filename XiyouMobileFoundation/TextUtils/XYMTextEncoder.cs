/**
 * Copyright (C) 2015 Xiyou Mobile Application Lab.
 * 
 * XiyouMobileFoundation
 * 
 * XYMTextEncoder.cs
 * 
 * Created by Yuan Guozheng on 2015-5-6.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XiyouMobileFoundation.TextUtils
{
    /// <summary>
    /// 转码工具类
    /// </summary>
    public class XYMTextEncoder
    {
        /// <summary>
        /// URL转码
        /// </summary>
        /// <param name="text">要转换的文本</param>
        /// <param name="code">转码类型</param>
        /// <returns>转换后的字符串</returns>
        public static string UrlEncode(string text, string code = "utf-8")
        {
            return System.Web.HttpUtility.UrlEncode(text, Encoding.GetEncoding(code));
        }
    }
}
