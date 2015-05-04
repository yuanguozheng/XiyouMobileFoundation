/**
 * Copyright (C) 2015 Xiyou Mobile Application Lab.
 * 
 * XiyouMobileMVCLib
 * 
 * XYMSuccessResult.cs
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
    /// 返回成功信息
    /// </summary>
    public class XYMSuccessResult
    {
        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="detail">详情</param>
        /// <returns>返回通用Api结果</returns>
        public static XYMApiResult ReturnSuccess(object detail)
        {
            XYMUniResult result = new XYMUniResult
            {
                Result = true,
                Detail = detail
            };
            XYMApiResult jsonpResult = new XYMApiResult(result);
            return jsonpResult;
        }
    }
}
