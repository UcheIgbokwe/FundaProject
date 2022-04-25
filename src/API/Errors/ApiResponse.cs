using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        private static string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request made",
                401 => "You are not authorized",
                404 => "Not found",
                500 => "Server Error!",
                _ => null
            };
        }
    }
}