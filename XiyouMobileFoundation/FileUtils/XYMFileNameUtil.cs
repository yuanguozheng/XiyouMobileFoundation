/**
 * Copyright (C) 2015 Xiyou Mobile Application Lab.
 * 
 * XiyouMobileFoundation
 * 
 * XYMFileNameUtil.cs
 * 
 * Created by Yuan Guozheng on 2015-5-6.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XiyouMobileFoundation.FileUtils
{
    /// <summary>
    /// 文件名工具类
    /// </summary>
    public class XYMFileNameUtil
    {
        /// <summary>
        /// 根据Uri获取文件名
        /// </summary>
        /// <param name="filename">Uri</param>
        /// <returns>文件名</returns>
        public static string GetFileName(Uri uri)
        {
            if (uri.IsFile)
            {
                return uri.Segments[uri.Segments.Length - 1];
            }
            return null;
        }

        /// <summary>
        /// 根据Uri获取文件的扩展名（默认包含.）
        /// </summary>
        /// <param name="filename">Uri</param>
        /// <returns>扩展名</returns>
        public static string GetExtension(Uri uri, bool withDot = true)
        {
            return GetExtension(GetFileName(uri), withDot);
        }

        /// <summary>
        /// 根据文件名获取文件的扩展名（默认包含.）
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>扩展名</returns>
        public static string GetExtension(string filename, bool withDot = true)
        {
            int index = filename.LastIndexOf('.');
            if (index == -1)
            {
                return null;
            }
            if (!withDot)
            {
                index++;
            }
            return filename.Substring(index);
        }
    }
}
