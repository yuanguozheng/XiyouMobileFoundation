# XiyouMobileFoundation
XiyouMobile 公共类库

## 功能介绍
该类库旨在提供常用的C#开发工具类，目前包括公共工具部分、公共模型部分、ASP.NET MVC部分

## 公共工具部分
__&#8226; 1.XYMNetworkUtils__ -> XYMHttpUtil -> HTTP请求工具类

使用示例：
```csharp
        static void Main(string[] args)
        {
            XYMHttpUtil http = new XYMHttpUtil();
            http.Completed += http_Completed;

            XYMHttpRequestModel model = new XYMHttpRequestModel();
            model.Url = "http://xiyoumobile.com/";
            model.Method = HttpMethod.GET;
            http.DoRequestWithModel(model);
        }

        static void http_Completed(XYMHttpResponseModel responseModel)
        {
            //TODO Handle Response
        }
```

__&#8226; 2.XYMTextUtils__ -> XYMTextEncoder 文本转码工具类

__&#8226; 3.XYMFileUtils__

 -> XYMFileNameUtil 文件名工具类

 -> XYMMimeMapping MIME工具类

## 公共模型部分
__&#8226; 1.XYMHttpPostFileModel__ -> 通用POST文件上传实体类

__&#8226; 2.XYMHttpRequestModel__ -> 通用HTTP请求实体类

__&#8226; 3.XYMHttpResponseModel__ -> 通用HTTP响应实体类

## MVC WebAPI模型部分
__&#8226; 1.XYMWebApiUniResult__ -> 通用Result实体类

## MVC WebAPI部分组成
__&#8226; 1.XYMWebApiResult__ -> 用于返回JSON或JSONP数据

__&#8226; 2.XYMWebApiResultManager__ -> 构建返回结果

## 欢迎继续补充
如有问题可发邮件至：yuanguozheng@outlook.com
