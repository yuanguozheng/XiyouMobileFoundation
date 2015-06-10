/**
 * Copyright (C) 2015 Xiyou Mobile Application Lab.
 * 
 * XiyouMobileFoundation
 * 
 * XYMImageUtils.cs
 * 
 * Created by Yuan Guozheng on 2015-6-10.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace XiyouMobileFoundation.ImageUtils
{
    /// <summary>
    /// 图片工具类
    /// </summary>
    public class XYMImageUtils
    {
        /// <summary>
        /// byte[] 转图片
        /// </summary>
        /// <param name="bytesArray">需要转换的Byte数组</param>
        /// <returns>Bitmap对象</returns>
        public static Bitmap BytesToBitmap(byte[] bytesArray)
        {
            MemoryStream stream = null;
            try
            {
                stream = new MemoryStream(bytesArray);
                return new Bitmap((Image)new Bitmap(stream));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            finally
            {
                stream.Close();
            }
        }

        /// <summary>
        /// 图片转byte[]
        /// </summary>
        /// <param name="bitmap">需要转换的Bitmap对象</param>
        /// <returns>Byte数组</returns>
        public static byte[] BitmapToBytes(Bitmap bitmap)
        {
            MemoryStream ms = null;
            try
            {
                ms = new MemoryStream();
                bitmap.Save(ms, bitmap.RawFormat);
                byte[] byteImage = new Byte[ms.Length];
                byteImage = ms.ToArray();
                return byteImage;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            finally
            {
                ms.Close();
            }
        }
    }
}
