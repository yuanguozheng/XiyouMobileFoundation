/**
 * Copyright (C) 2015 Xiyou Mobile Application Lab.
 * 
 * XiyouMobileMVCLib
 * 
 * XYMErrorResult.cs
 * 
 * Created by Yuan Guozheng on 2015-5-5.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiyouMobileMVCLib.WebAPI
{
    /// <summary>
    /// 返回错误信息
    /// </summary>
    public class XYMErrorsResult
    {
        /// <summary>
        /// 返回错误
        /// </summary>
        /// <param name="type">错误类型</param>
        /// <returns>通用结果</returns>
        public static XYMApiResult ReturnError(ErrorTypes type)
        {
            XYMUniResult result = new XYMUniResult
            {
                Result = false,
                Detail = type.ToString()
            };
            XYMApiResult jsonpResult = new XYMApiResult(result);
            return jsonpResult;
        }

        /// <summary>
        /// 返回错误
        /// </summary>
        /// <param name="data">错误内容</param>
        /// <returns>通用结果</returns>
        public static XYMApiResult ReturnError(object data)
        {
            XYMUniResult result = new XYMUniResult
            {
                Result = false,
                Detail = data
            };
            XYMApiResult jsonpResult = new XYMApiResult(result);
            return jsonpResult;
        }
    }

    /// <summary>
    /// 错误类型枚举
    /// </summary>
    public enum ErrorTypes
    {
        NOT_FOUND, SERVER_ERROR, PARAM_ERROR, DB_ERROR, METHOD_NOT_ALLOW,
        USER_NOT_EXISTED, USER_EXISTED, USER_NOT_AVALIABLE, NOT_LOGIN, VERIFIED_FAILED,
        UNKNOWN_ERROR
    }
}
