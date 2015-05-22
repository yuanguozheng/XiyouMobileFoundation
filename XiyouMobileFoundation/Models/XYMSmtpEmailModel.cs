/**
 * Copyright (C) 2015 Xiyou Mobile Application Lab.
 * 
 * XiyouMobileFoundation
 * 
 * XYMSmtpEmailModel.cs
 * 
 * Created by Yuan Guozheng on 2015-5-22.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.IO;

namespace XiyouMobileFoundation.Models
{
    /// <summary>
    /// Email发送实体类
    /// </summary>
    public class XYMSmtpEmailModel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public XYMSmtpEmailModel()
        {
            AttachmentFiles = new List<string>();
        }

        /// <summary>
        /// 发件人
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// 收件人
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Smtp服务器地址
        /// </summary>
        public string SmtpServerAddress { get; set; }

        /// <summary>
        /// 附件文件列表
        /// </summary>
        public List<string> AttachmentFiles { get; set; }

        /// <summary>
        /// 正文是否使用HTML
        /// </summary>
        public bool IsBodyHtml { get; set; }

        /// <summary>
        /// 主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        public string Body { get; set; }
    }
}
