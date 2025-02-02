﻿using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Infrastructre.Extensions
{
    public static class HttpRequestExtension 
    {
        public static string PathAndQuery(this HttpRequest request)
        {
            return request.QueryString.HasValue
                ? $"{request.Path}{request.QueryString}"
                : request.Path.ToString();
        }
    }
}
