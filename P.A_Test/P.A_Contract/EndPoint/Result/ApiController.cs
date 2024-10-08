﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace P.A_Contract.EndPoint.Result
{
    public class ApiController : ControllerBase
    {
        [NonAction]
        public ApiResult CommandResult()
        {
            //HttpContext.Response.StatusCode = (int)result.Status;
            return new ApiResult()
            {
                IsSuccess = true,
                MetaData = new()
                {
                    Message = "Operation was Successfull",
                    AppStatusCode = AppStatusCode.Success,
                }
            };
        }

        public ApiResult<TData?> CommandResult<TData>(OperationResult<TData> result
            , string locationUrl = null)
        {
            bool isSuccess = result.Status == OperationResultStatus.Success;
            if (isSuccess)
            {
                //HttpContext.Response.StatusCode =(int) HttpStatusCode.OK;
                if (!string.IsNullOrWhiteSpace(locationUrl))
                {
                    HttpContext.Response.Headers.Add("location", locationUrl);
                }
            }
            return new ApiResult<TData?>()
            {
                IsSuccess = isSuccess,
                Data = isSuccess ? result.Data : default,
                MetaData = new()
                {
                    Message = result.Message,
                    AppStatusCode = result.Status.MapOperationStatus()
                }
            };
        }

        [NonAction]
        public ApiResult<TData> QueryResult<TData>(TData result)
        {
            //HttpContext.Response.StatusCode = (int)result.Status;
            if (result != null)
            {
                return new ApiResult<TData>()
                {
                    IsSuccess = true,
                    Data = result,
                    MetaData = new()
                    {
                        Message = "Data uploded Successfully",
                        AppStatusCode = AppStatusCode.Success
                    }
                };
            }
            return new ApiResult<TData>()
            {
                IsSuccess = true,
                MetaData = new()
                {
                    Message = "Data uploded Successfully",
                    AppStatusCode = AppStatusCode.Success
                }
            };

        }

    }
    public static class EnumHelper
    {
        public static AppStatusCode MapOperationStatus(this OperationResultStatus status)
        {
            switch (status)
            {
                case OperationResultStatus.Success:
                    return AppStatusCode.Success;

                case OperationResultStatus.NotFound:
                    return AppStatusCode.NotFound;

                case OperationResultStatus.Error:
                    return AppStatusCode.LogicError;
            }
            return AppStatusCode.LogicError;
        }
    }
}
