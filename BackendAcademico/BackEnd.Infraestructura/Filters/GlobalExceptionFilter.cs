using BackEnd.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BackEnd.Infraestructura.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        void IExceptionFilter.OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BussinesException))
            {
                var exception = (BussinesException) context.Exception;

                // creacion de clase anonima
                var validation = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = exception.Message
                };

                var json = new
                {
                    errors = new[] { validation }
                };
                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}
