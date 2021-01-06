using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.App.Diagram.Api.Services
{
    public class ResultFactory
    {
        public static Result buildSuccessResult(String massage, Object data)
        {
            return buildResult(ResultCode.SUCCESS.GetHashCode(), massage, data, null);
        }

        public static Result buildSuccessResult(String massage, Object data, String sessionId)
        {
            return buildResult(ResultCode.SUCCESS.GetHashCode(), massage, data, sessionId);
        }

        public static Result buildFailResult(String message)
        {
            return buildResult(ResultCode.FAIL.GetHashCode(), message, null, null);
        }

        public static Result buildResult(int resultcode, String message, Object data, String sessionId)
        {
            return new Result(resultcode, message, data, null, sessionId);
        }
    }

    public class Result
    {
        public int code { set; get; }
        public string message { set; get; }
        public object data { set; get; }
        public string Text { get; set; }
        public string FolderName { get; set; }

        public Result(int code, string message, object data, string text, string folderName)
        {
            this.code = code;
            this.message = message;
            this.data = data;
            this.Text = text;
            this.FolderName = folderName;
        }
    }

    public enum ResultCode
    {
        SUCCESS = 200,
        FAIL = 400,
        UNAUTHORIZED = 401,
        NOT_FOUND = 404,
        INTERNAL_SERVER_ERROR = 500,
    }

    public class FileInfoRequest
    {
        public string FileName { get; set; }
        public string FolderName { get; set; }
    }
}