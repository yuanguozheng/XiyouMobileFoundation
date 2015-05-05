/**
 * Copyright (C) 2015 Xiyou Mobile Application Lab.
 * 
 * XiyouMobileFoundation
 * 
 * XYMApiResult.cs
 * 
 * Created by Yuan Guozheng on 2015-5-5.
 */
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace XiyouMobileFoundation.WebAPI
{
    /// <summary>
    /// 返回Api结果
    /// </summary>
    public class XYMWebApiResult : JsonResult
    {
        /// <summary>
        /// 默认Content-Type
        /// </summary>
        private const string DEFAULT_CONTENT_TYPE = "application/json; charset=utf-8";

        /// <summary>
        /// JSONP回调方法名参数名
        /// </summary>
        private static string JsonpParam = "callback";

        /// <summary>
        /// 保存数据
        /// </summary>
        private object data = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public XYMWebApiResult()
        {
            this.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }

        /// <summary>
        /// 带返回数据的构造函数
        /// </summary>
        /// <param name="data">要返回的数据</param>
        public XYMWebApiResult(object data)
        {
            this.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            this.data = data;
        }

        /// <summary>
        /// 设置JSONP回调函数名参数名
        /// </summary>
        /// <param name="param">参数名</param>
        public void setJsonpParam(string param)
        {
            if (string.IsNullOrWhiteSpace(param))
            {
                return;
            }
            JsonpParam = param;
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="controllerContext">控制器上下文</param>
        public override void ExecuteResult(ControllerContext controllerContext)
        {
            if (controllerContext != null)
            {
                HttpResponseBase Response = controllerContext.HttpContext.Response;
                HttpRequestBase Request = controllerContext.HttpContext.Request;
                string callbackfunction = Request[JsonpParam];
                Response.ContentType = DEFAULT_CONTENT_TYPE;
                if (data != null)
                {
                    if (string.IsNullOrWhiteSpace(callbackfunction))
                        Response.Write(JsonConvert.SerializeObject(data));
                    else
                        Response.Write(string.Format("{0}({1})", callbackfunction, JsonConvert.SerializeObject(data)));
                }
            }
        }
    }
}
