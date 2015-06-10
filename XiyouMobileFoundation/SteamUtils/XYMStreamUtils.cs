/**
 * Copyright (C) 2015 Xiyou Mobile Application Lab.
 * 
 * XiyouMobileFoundation
 * 
 * XYMStreamUtils.cs
 * 
 * Created by Yuan Guozheng on 2015-6-10.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XiyouMobileFoundation.SteamUtils
{
    /// <summary>
    /// 流工具类
    /// </summary>
    public class XYMStreamUtils
    {
        /// <summary>
        /// 将 Stream 转成 byte[] 
        /// </summary>
        /// <param name="stream">流对象</param>
        /// <returns>Byte数组</returns>
        public byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        /// <summary>  
        /// 将 byte[] 转成 Stream  
        /// </summary>  
        /// <param name="bytes">Byte数组</param>
        /// <returns>流对象</returns>
        public Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
    }
}
