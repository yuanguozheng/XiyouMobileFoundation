/**
 * Copyright (C) 2015 Xiyou Mobile Application Lab.
 * 
 * XiyouMobileMVCLib
 * 
 * XYMWebApiResultManager.cs
 * 
 * Created by Yuan Guozheng on 2015-5-5.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XiyouMobileMVCLib.WebAPI
{
    /// <summary>
    /// API常见错误类型枚举
    /// </summary>
    public enum WebApiErrorTypes
    {
        NOT_FOUND, SERVER_ERROR, PARAM_ERROR, DB_ERROR, METHOD_NOT_ALLOW,
        USER_NOT_EXISTED, USER_EXISTED, USER_NOT_AVALIABLE, NOT_LOGIN, VERIFIED_FAILED,
        UNKNOWN_ERROR
    }

    /// <summary>
    /// 用于获得返回结果对象
    /// </summary>
    public class XYMWebApiResultManager
    {
        /// <summary>
        /// 获得返回结果对象
        /// </summary>
        /// <param name="isSuccess">返回值是否合法</param>
        /// <param name="msg">返回内容</param>
        /// <returns>XYMWebApiResult 对象</returns>
        public static XYMWebApiResult GetResult(bool isSuccess, object msg)
        {
            XYMWebApiUniResult model = new XYMWebApiUniResult
            {
                Result = isSuccess,
                Detail = msg
            };
            XYMWebApiResult result = new XYMWebApiResult(model);
            return result;
        }

        /// <summary>
        /// 直接返回错误对象
        /// </summary>
        /// <param name="type">错误类型</param>
        /// <returns>错误对象</returns>
        public static XYMWebApiResult GetErrorResult(WebApiErrorTypes type)
        {
            return GetResult(false, type.ToString());
        }

    }
}
