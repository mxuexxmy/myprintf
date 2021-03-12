using System;
using System.Collections.Generic;
using System.Linq;


namespace myprint.Entity
{
    public class Result
    {
        public static int STATUS_SUCCESS = 200;
        public static int STATUS_FAIL = 500;

        public int status { get; set; }
        public string message { get; set; }

        public static Result success()
        {
            return Result.createResult(STATUS_SUCCESS, "成功");
        }

        public static Result fail()
        {
            return Result.createResult(STATUS_FAIL, "失败");
        }

        public static Result success(String message)
        {
            return Result.createResult(STATUS_SUCCESS, message);
        }

        public static Result fail(string message)
        {
            return Result.createResult(STATUS_FAIL, message);
        }

        public static Result fail(int status, string message)
        {
            return Result.createResult(status, message);
        }
        private static Result createResult(int status, string message)
        {
            Result Result = new Result();
            Result.status = status;
            Result.message = message;
            return Result;
        }
    }
}