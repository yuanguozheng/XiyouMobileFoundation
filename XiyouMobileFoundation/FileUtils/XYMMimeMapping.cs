/**
 * Copyright (C) 2015 Xiyou Mobile Application Lab.
 * 
 * XiyouMobileFoundation
 * 
 * XYMMimeMapping.cs
 * 
 * Created by Yuan Guozheng on 2015-5-6.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XiyouMobileFoundation.FileUtils
{
    /// <summary>
    /// MIME字典，用于获得MIME类型
    /// </summary>
    public static class XYMMimeMapping
    {
        /// <summary>
        /// MIME字典
        /// </summary>
        private static Dictionary<string, string> mimeDict;

        /// <summary>
        /// 使用文件名获取MIME
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>MIME字符串</returns>
        public static string GetMimeByName(string fileName)
        {
            return GetMimeByExt(XYMFileNameUtil.GetExtension(fileName));
        }

        /// <summary>
        /// 使用扩展名获取MIME
        /// </summary>
        /// <param name="ext">扩展名</param>
        /// <returns>MIME字符串</returns>
        public static string GetMimeByExt(string ext)
        {
            string mime;
            if (!mimeDict.ContainsKey(ext))
            {
                mime = null;
            }
            else
            {
                mime = mimeDict[ext];
            }
            if (string.IsNullOrWhiteSpace(mime))
            {
                mime = (string)XYMMimeMapping.mimeDict[".*"];
            }
            return mime;
        }

        /// <summary>
        /// 添加MIME类型
        /// </summary>
        /// <param name="extension">文件扩展名</param>
        /// <param name="mimeType">MIME字符串</param>
        private static void AddMimeMapping(string extension, string mimeType)
        {
            XYMMimeMapping.mimeDict.Add(extension, mimeType);
        }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        static XYMMimeMapping()
        {
            XYMMimeMapping.mimeDict = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            XYMMimeMapping.AddMimeMapping(".323", "text/h323");
            XYMMimeMapping.AddMimeMapping(".asx", "video/x-ms-asf");
            XYMMimeMapping.AddMimeMapping(".acx", "application/internet-property-stream");
            XYMMimeMapping.AddMimeMapping(".ai", "application/postscript");
            XYMMimeMapping.AddMimeMapping(".aif", "audio/x-aiff");
            XYMMimeMapping.AddMimeMapping(".aiff", "audio/aiff");
            XYMMimeMapping.AddMimeMapping(".axs", "application/olescript");
            XYMMimeMapping.AddMimeMapping(".aifc", "audio/aiff");
            XYMMimeMapping.AddMimeMapping(".asr", "video/x-ms-asf");
            XYMMimeMapping.AddMimeMapping(".avi", "video/x-msvideo");
            XYMMimeMapping.AddMimeMapping(".asf", "video/x-ms-asf");
            XYMMimeMapping.AddMimeMapping(".au", "audio/basic");
            XYMMimeMapping.AddMimeMapping(".application", "application/x-ms-application");
            XYMMimeMapping.AddMimeMapping(".bin", "application/octet-stream");
            XYMMimeMapping.AddMimeMapping(".bas", "text/plain");
            XYMMimeMapping.AddMimeMapping(".bcpio", "application/x-bcpio");
            XYMMimeMapping.AddMimeMapping(".bmp", "image/bmp");
            XYMMimeMapping.AddMimeMapping(".cdf", "application/x-cdf");
            XYMMimeMapping.AddMimeMapping(".cat", "application/vndms-pkiseccat");
            XYMMimeMapping.AddMimeMapping(".crt", "application/x-x509-ca-cert");
            XYMMimeMapping.AddMimeMapping(".c", "text/plain");
            XYMMimeMapping.AddMimeMapping(".css", "text/css");
            XYMMimeMapping.AddMimeMapping(".cer", "application/x-x509-ca-cert");
            XYMMimeMapping.AddMimeMapping(".crl", "application/pkix-crl");
            XYMMimeMapping.AddMimeMapping(".cmx", "image/x-cmx");
            XYMMimeMapping.AddMimeMapping(".csh", "application/x-csh");
            XYMMimeMapping.AddMimeMapping(".cod", "image/cis-cod");
            XYMMimeMapping.AddMimeMapping(".cpio", "application/x-cpio");
            XYMMimeMapping.AddMimeMapping(".clp", "application/x-msclip");
            XYMMimeMapping.AddMimeMapping(".crd", "application/x-mscardfile");
            XYMMimeMapping.AddMimeMapping(".deploy", "application/octet-stream");
            XYMMimeMapping.AddMimeMapping(".dll", "application/x-msdownload");
            XYMMimeMapping.AddMimeMapping(".dot", "application/msword");
            XYMMimeMapping.AddMimeMapping(".doc", "application/msword");
            XYMMimeMapping.AddMimeMapping(".dvi", "application/x-dvi");
            XYMMimeMapping.AddMimeMapping(".dir", "application/x-director");
            XYMMimeMapping.AddMimeMapping(".dxr", "application/x-director");
            XYMMimeMapping.AddMimeMapping(".der", "application/x-x509-ca-cert");
            XYMMimeMapping.AddMimeMapping(".dib", "image/bmp");
            XYMMimeMapping.AddMimeMapping(".dcr", "application/x-director");
            XYMMimeMapping.AddMimeMapping(".disco", "text/xml");
            XYMMimeMapping.AddMimeMapping(".exe", "application/octet-stream");
            XYMMimeMapping.AddMimeMapping(".etx", "text/x-setext");
            XYMMimeMapping.AddMimeMapping(".evy", "application/envoy");
            XYMMimeMapping.AddMimeMapping(".eml", "message/rfc822");
            XYMMimeMapping.AddMimeMapping(".eps", "application/postscript");
            XYMMimeMapping.AddMimeMapping(".flr", "x-world/x-vrml");
            XYMMimeMapping.AddMimeMapping(".fif", "application/fractals");
            XYMMimeMapping.AddMimeMapping(".gtar", "application/x-gtar");
            XYMMimeMapping.AddMimeMapping(".gif", "image/gif");
            XYMMimeMapping.AddMimeMapping(".gz", "application/x-gzip");
            XYMMimeMapping.AddMimeMapping(".hta", "application/hta");
            XYMMimeMapping.AddMimeMapping(".htc", "text/x-component");
            XYMMimeMapping.AddMimeMapping(".htt", "text/webviewhtml");
            XYMMimeMapping.AddMimeMapping(".h", "text/plain");
            XYMMimeMapping.AddMimeMapping(".hdf", "application/x-hdf");
            XYMMimeMapping.AddMimeMapping(".hlp", "application/winhlp");
            XYMMimeMapping.AddMimeMapping(".html", "text/html");
            XYMMimeMapping.AddMimeMapping(".htm", "text/html");
            XYMMimeMapping.AddMimeMapping(".hqx", "application/mac-binhex40");
            XYMMimeMapping.AddMimeMapping(".isp", "application/x-internet-signup");
            XYMMimeMapping.AddMimeMapping(".iii", "application/x-iphone");
            XYMMimeMapping.AddMimeMapping(".ief", "image/ief");
            XYMMimeMapping.AddMimeMapping(".ivf", "video/x-ivf");
            XYMMimeMapping.AddMimeMapping(".ins", "application/x-internet-signup");
            XYMMimeMapping.AddMimeMapping(".ico", "image/x-icon");
            XYMMimeMapping.AddMimeMapping(".jpg", "image/jpeg");
            XYMMimeMapping.AddMimeMapping(".jfif", "image/pjpeg");
            XYMMimeMapping.AddMimeMapping(".jpe", "image/jpeg");
            XYMMimeMapping.AddMimeMapping(".jpeg", "image/jpeg");
            XYMMimeMapping.AddMimeMapping(".js", "application/x-javascript");
            XYMMimeMapping.AddMimeMapping(".lsx", "video/x-la-asf");
            XYMMimeMapping.AddMimeMapping(".latex", "application/x-latex");
            XYMMimeMapping.AddMimeMapping(".lsf", "video/x-la-asf");
            XYMMimeMapping.AddMimeMapping(".manifest", "application/x-ms-manifest");
            XYMMimeMapping.AddMimeMapping(".mhtml", "message/rfc822");
            XYMMimeMapping.AddMimeMapping(".mny", "application/x-msmoney");
            XYMMimeMapping.AddMimeMapping(".mht", "message/rfc822");
            XYMMimeMapping.AddMimeMapping(".mid", "audio/mid");
            XYMMimeMapping.AddMimeMapping(".mpv2", "video/mpeg");
            XYMMimeMapping.AddMimeMapping(".man", "application/x-troff-man");
            XYMMimeMapping.AddMimeMapping(".mvb", "application/x-msmediaview");
            XYMMimeMapping.AddMimeMapping(".mpeg", "video/mpeg");
            XYMMimeMapping.AddMimeMapping(".m3u", "audio/x-mpegurl");
            XYMMimeMapping.AddMimeMapping(".mdb", "application/x-msaccess");
            XYMMimeMapping.AddMimeMapping(".mpp", "application/vnd.ms-project");
            XYMMimeMapping.AddMimeMapping(".m1v", "video/mpeg");
            XYMMimeMapping.AddMimeMapping(".mpa", "video/mpeg");
            XYMMimeMapping.AddMimeMapping(".me", "application/x-troff-me");
            XYMMimeMapping.AddMimeMapping(".m13", "application/x-msmediaview");
            XYMMimeMapping.AddMimeMapping(".movie", "video/x-sgi-movie");
            XYMMimeMapping.AddMimeMapping(".m14", "application/x-msmediaview");
            XYMMimeMapping.AddMimeMapping(".mpe", "video/mpeg");
            XYMMimeMapping.AddMimeMapping(".mp2", "video/mpeg");
            XYMMimeMapping.AddMimeMapping(".mov", "video/quicktime");
            XYMMimeMapping.AddMimeMapping(".mp3", "audio/mpeg");
            XYMMimeMapping.AddMimeMapping(".mpg", "video/mpeg");
            XYMMimeMapping.AddMimeMapping(".ms", "application/x-troff-ms");
            XYMMimeMapping.AddMimeMapping(".nc", "application/x-netcdf");
            XYMMimeMapping.AddMimeMapping(".nws", "message/rfc822");
            XYMMimeMapping.AddMimeMapping(".oda", "application/oda");
            XYMMimeMapping.AddMimeMapping(".ods", "application/oleobject");
            XYMMimeMapping.AddMimeMapping(".pmc", "application/x-perfmon");
            XYMMimeMapping.AddMimeMapping(".p7r", "application/x-pkcs7-certreqresp");
            XYMMimeMapping.AddMimeMapping(".p7b", "application/x-pkcs7-certificates");
            XYMMimeMapping.AddMimeMapping(".p7s", "application/pkcs7-signature");
            XYMMimeMapping.AddMimeMapping(".pmw", "application/x-perfmon");
            XYMMimeMapping.AddMimeMapping(".ps", "application/postscript");
            XYMMimeMapping.AddMimeMapping(".p7c", "application/pkcs7-mime");
            XYMMimeMapping.AddMimeMapping(".pbm", "image/x-portable-bitmap");
            XYMMimeMapping.AddMimeMapping(".ppm", "image/x-portable-pixmap");
            XYMMimeMapping.AddMimeMapping(".pub", "application/x-mspublisher");
            XYMMimeMapping.AddMimeMapping(".pnm", "image/x-portable-anymap");
            XYMMimeMapping.AddMimeMapping(".png", "image/png");
            XYMMimeMapping.AddMimeMapping(".pml", "application/x-perfmon");
            XYMMimeMapping.AddMimeMapping(".p10", "application/pkcs10");
            XYMMimeMapping.AddMimeMapping(".pfx", "application/x-pkcs12");
            XYMMimeMapping.AddMimeMapping(".p12", "application/x-pkcs12");
            XYMMimeMapping.AddMimeMapping(".pdf", "application/pdf");
            XYMMimeMapping.AddMimeMapping(".pps", "application/vnd.ms-powerpoint");
            XYMMimeMapping.AddMimeMapping(".p7m", "application/pkcs7-mime");
            XYMMimeMapping.AddMimeMapping(".pko", "application/vndms-pkipko");
            XYMMimeMapping.AddMimeMapping(".ppt", "application/vnd.ms-powerpoint");
            XYMMimeMapping.AddMimeMapping(".pmr", "application/x-perfmon");
            XYMMimeMapping.AddMimeMapping(".pma", "application/x-perfmon");
            XYMMimeMapping.AddMimeMapping(".pot", "application/vnd.ms-powerpoint");
            XYMMimeMapping.AddMimeMapping(".prf", "application/pics-rules");
            XYMMimeMapping.AddMimeMapping(".pgm", "image/x-portable-graymap");
            XYMMimeMapping.AddMimeMapping(".qt", "video/quicktime");
            XYMMimeMapping.AddMimeMapping(".ra", "audio/x-pn-realaudio");
            XYMMimeMapping.AddMimeMapping(".rgb", "image/x-rgb");
            XYMMimeMapping.AddMimeMapping(".ram", "audio/x-pn-realaudio");
            XYMMimeMapping.AddMimeMapping(".rmi", "audio/mid");
            XYMMimeMapping.AddMimeMapping(".ras", "image/x-cmu-raster");
            XYMMimeMapping.AddMimeMapping(".roff", "application/x-troff");
            XYMMimeMapping.AddMimeMapping(".rtf", "application/rtf");
            XYMMimeMapping.AddMimeMapping(".rtx", "text/richtext");
            XYMMimeMapping.AddMimeMapping(".sv4crc", "application/x-sv4crc");
            XYMMimeMapping.AddMimeMapping(".spc", "application/x-pkcs7-certificates");
            XYMMimeMapping.AddMimeMapping(".setreg", "application/set-registration-initiation");
            XYMMimeMapping.AddMimeMapping(".snd", "audio/basic");
            XYMMimeMapping.AddMimeMapping(".stl", "application/vndms-pkistl");
            XYMMimeMapping.AddMimeMapping(".setpay", "application/set-payment-initiation");
            XYMMimeMapping.AddMimeMapping(".stm", "text/html");
            XYMMimeMapping.AddMimeMapping(".shar", "application/x-shar");
            XYMMimeMapping.AddMimeMapping(".sh", "application/x-sh");
            XYMMimeMapping.AddMimeMapping(".sit", "application/x-stuffit");
            XYMMimeMapping.AddMimeMapping(".spl", "application/futuresplash");
            XYMMimeMapping.AddMimeMapping(".sct", "text/scriptlet");
            XYMMimeMapping.AddMimeMapping(".scd", "application/x-msschedule");
            XYMMimeMapping.AddMimeMapping(".sst", "application/vndms-pkicertstore");
            XYMMimeMapping.AddMimeMapping(".src", "application/x-wais-source");
            XYMMimeMapping.AddMimeMapping(".sv4cpio", "application/x-sv4cpio");
            XYMMimeMapping.AddMimeMapping(".tex", "application/x-tex");
            XYMMimeMapping.AddMimeMapping(".tgz", "application/x-compressed");
            XYMMimeMapping.AddMimeMapping(".t", "application/x-troff");
            XYMMimeMapping.AddMimeMapping(".tar", "application/x-tar");
            XYMMimeMapping.AddMimeMapping(".tr", "application/x-troff");
            XYMMimeMapping.AddMimeMapping(".tif", "image/tiff");
            XYMMimeMapping.AddMimeMapping(".txt", "text/plain");
            XYMMimeMapping.AddMimeMapping(".texinfo", "application/x-texinfo");
            XYMMimeMapping.AddMimeMapping(".trm", "application/x-msterminal");
            XYMMimeMapping.AddMimeMapping(".tiff", "image/tiff");
            XYMMimeMapping.AddMimeMapping(".tcl", "application/x-tcl");
            XYMMimeMapping.AddMimeMapping(".texi", "application/x-texinfo");
            XYMMimeMapping.AddMimeMapping(".tsv", "text/tab-separated-values");
            XYMMimeMapping.AddMimeMapping(".ustar", "application/x-ustar");
            XYMMimeMapping.AddMimeMapping(".uls", "text/iuls");
            XYMMimeMapping.AddMimeMapping(".vcf", "text/x-vcard");
            XYMMimeMapping.AddMimeMapping(".wps", "application/vnd.ms-works");
            XYMMimeMapping.AddMimeMapping(".wav", "audio/wav");
            XYMMimeMapping.AddMimeMapping(".wrz", "x-world/x-vrml");
            XYMMimeMapping.AddMimeMapping(".wri", "application/x-mswrite");
            XYMMimeMapping.AddMimeMapping(".wks", "application/vnd.ms-works");
            XYMMimeMapping.AddMimeMapping(".wmf", "application/x-msmetafile");
            XYMMimeMapping.AddMimeMapping(".wcm", "application/vnd.ms-works");
            XYMMimeMapping.AddMimeMapping(".wrl", "x-world/x-vrml");
            XYMMimeMapping.AddMimeMapping(".wdb", "application/vnd.ms-works");
            XYMMimeMapping.AddMimeMapping(".wsdl", "text/xml");
            XYMMimeMapping.AddMimeMapping(".xap", "application/x-silverlight-app");
            XYMMimeMapping.AddMimeMapping(".xml", "text/xml");
            XYMMimeMapping.AddMimeMapping(".xlm", "application/vnd.ms-excel");
            XYMMimeMapping.AddMimeMapping(".xaf", "x-world/x-vrml");
            XYMMimeMapping.AddMimeMapping(".xla", "application/vnd.ms-excel");
            XYMMimeMapping.AddMimeMapping(".xls", "application/vnd.ms-excel");
            XYMMimeMapping.AddMimeMapping(".xof", "x-world/x-vrml");
            XYMMimeMapping.AddMimeMapping(".xlt", "application/vnd.ms-excel");
            XYMMimeMapping.AddMimeMapping(".xlc", "application/vnd.ms-excel");
            XYMMimeMapping.AddMimeMapping(".xsl", "text/xml");
            XYMMimeMapping.AddMimeMapping(".xbm", "image/x-xbitmap");
            XYMMimeMapping.AddMimeMapping(".xlw", "application/vnd.ms-excel");
            XYMMimeMapping.AddMimeMapping(".xpm", "image/x-xpixmap");
            XYMMimeMapping.AddMimeMapping(".xwd", "image/x-xwindowdump");
            XYMMimeMapping.AddMimeMapping(".xsd", "text/xml");
            XYMMimeMapping.AddMimeMapping(".z", "application/x-compress");
            XYMMimeMapping.AddMimeMapping(".zip", "application/x-zip-compressed");
            XYMMimeMapping.AddMimeMapping(".mp4", "video/mp4");
            XYMMimeMapping.AddMimeMapping(".*", "application/octet-stream");
        }
    }
}
