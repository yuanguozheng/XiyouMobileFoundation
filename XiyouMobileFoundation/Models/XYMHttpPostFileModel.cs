/**
 * Copyright (C) 2015 Xiyou Mobile Application Lab.
 * 
 * XiyouMobileFoundation
 * 
 * XYMHttpPostFileModel.cs
 * 
 * Created by Yuan Guozheng on 2015-5-6.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mime;

namespace XiyouMobileFoundation.Models
{
    /// <summary>
    /// HTTP上传文件信息实体类
    /// </summary>
    public class XYMHttpPostFileModel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fileUri">文件Uri</param>
        public XYMHttpPostFileModel(String key, Uri fileUri)
        {
            FileUri = fileUri;
            Key = key;
        }

        public String Key { get; set; }

        /// <summary>
        /// 文件Uri（只读）
        /// </summary>
        public Uri FileUri { get; set; }

        /// <summary>
        /// 文件名（只读）
        /// </summary>
        public String FileName
        {
            get
            {
                if (FileUri != null)
                {
                    return FileUtils.XYMFileNameUtil.GetFileName(FileUri);
                }
                return null;
            }
        }

        /// <summary>
        /// MIME（只读）
        /// </summary>
        public String Mime
        {
            get
            {
                if (String.IsNullOrWhiteSpace(FileName))
                {
                    return null;
                }
                return FileUtils.XYMMimeMapping.GetMimeByName(FileName);
            }
        }
    }
}
