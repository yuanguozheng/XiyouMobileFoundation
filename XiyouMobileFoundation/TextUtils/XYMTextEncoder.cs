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
        private const string DEFAULT_CODE = "UTF-8";  // 默认编码

        /// <summary>
        /// URL转码
        /// </summary>
        /// <param name="text">要转换的文本</param>
        /// <param name="code">转码类型</param>
        /// <returns>转换后的字符串</returns>
        public static string UrlEncode(string text, string code = DEFAULT_CODE)
        {
            return System.Web.HttpUtility.UrlEncode(text, GetCode(code));
        }

        /// <summary>
        /// GBK转UTF-8
        /// </summary>
        /// <param name="data">GBK编码流</param>
        /// <returns>UTF-8字符串</returns>
        public static string GBKToUTF8(byte[] data)
        {
            byte[] trans = Encoding.Convert(GetCode("GBK"), Encoding.UTF8, data);
            return Encoding.UTF8.GetString(trans);
        }

        /// <summary>
        /// GB2312转UTF-8
        /// </summary>
        /// <param name="data">GB2312编码流</param>
        /// <returns>UTF-8字符串</returns>
        public static string GB2312ToUTF8(byte[] data)
        {
            byte[] trans = Encoding.Convert(GetCode("GB2312"), Encoding.UTF8, data);
            return Encoding.UTF8.GetString(trans);
        }

        /// <summary>
        /// ISO8859-1转UTF-8
        /// </summary>
        /// <param name="data">ISO8859-1编码流</param>
        /// <returns>UTF-8字符串</returns>
        public static string ISO8859ToUTF8(byte[] data)
        {
            byte[] trans = Encoding.Convert(GetCode("ISO8859-1"), Encoding.UTF8, data);
            return Encoding.UTF8.GetString(trans);
        }

        /// <summary>
        /// Bytes转Base64
        /// </summary>
        /// <param name="obj">需要转换的流</param>
        /// <returns>转换后的字符串</returns>
        public static string BytesToBase64(byte[] obj)
        {
            return Convert.ToBase64String(obj);
        }

        /// <summary>
        /// String转Base64
        /// </summary>
        /// <param name="text">需要转换的文本</param>
        /// <returns>转换后的字符串</returns>
        public static string StringToBase64(string text, string code = DEFAULT_CODE)
        {
            return Convert.ToBase64String(GetCode(code).GetBytes(text));
        }

        /// <summary>
        /// 获取编码
        /// </summary>
        /// <param name="code">编码类型</param>
        /// <returns>Encoding类型数据</returns>
        private static Encoding GetCode(string code)
        {
            return Encoding.GetEncoding(code);
        }
    }
}
