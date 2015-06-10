/**
 * Copyright (C) 2015 Xiyou Mobile Application Lab.
 * 
 * XiyouMobileFoundation
 * 
 * XYMFileOperator.cs
 * 
 * Created by Yuan Guozheng on 2015-6-10.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XiyouMobileFoundation.FileUtils
{
    /// <summary>
    /// 文件操作工具类
    /// </summary>
    public class XYMFileOperator
    {
        /// <summary>
        /// 将 Stream 写入文件 
        /// </summary>
        /// <param name="stream">流对象</param>
        /// <param name="fileName">输出文件名</param>
        public void StreamToFile(Stream stream, string fileName)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin);
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }

        /// <summary>
        /// 从文件读取 Stream 
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>流对象</returns>
        public Stream FileToStream(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
    }
}
