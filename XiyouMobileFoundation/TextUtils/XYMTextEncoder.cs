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

        /// <summary>
        /// GBK转UTF-8
        /// </summary>
        /// <param name="data">GBK编码流</param>
        /// <returns>UTF-8字符串</returns>
        public static string GBKToUTF8(byte[] data)
        {
            byte[] trans = Encoding.Convert(Encoding.GetEncoding("GBK"), Encoding.UTF8, data);
            return Encoding.UTF8.GetString(trans);
        }

        /// <summary>
        /// GB2312转UTF-8
        /// </summary>
        /// <param name="data">GB2312编码流</param>
        /// <returns>UTF-8字符串</returns>
        public static string GB2312ToUTF8(byte[] data)
        {
            byte[] trans = Encoding.Convert(Encoding.GetEncoding("GB2312"), Encoding.UTF8, data);
            return Encoding.UTF8.GetString(trans);
        }

        /// <summary>
        /// ISO8859-1转UTF-8
        /// </summary>
        /// <param name="data">ISO8859-1编码流</param>
        /// <returns>UTF-8字符串</returns>
        public static string GB2312ToUTF8(byte[] data)
        {
            byte[] trans = Encoding.Convert(Encoding.GetEncoding("ISO8859-1"), Encoding.UTF8, data);
            return Encoding.UTF8.GetString(trans);
        }
    }
}
