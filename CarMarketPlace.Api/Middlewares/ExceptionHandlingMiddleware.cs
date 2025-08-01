﻿using System.Text.Json;
using CarMarketPlace.Core.Errors;

namespace CarMarketPlace.Api.Middlewares;
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = 500;
        context.Response.ContentType = "application/json";

        if (exception is EntityNotFoundException)
        {
            code = 404;
        }
        else if (exception is AuthException || exception is UnauthorizedException)
        {
            code = 401;
        }
        else if (exception is ForbiddenException || exception is NotAllowedException)
        {
            code = 403;
        }

        context.Response.StatusCode = code;

        var response = new
        {
            StatusCode = context.Response.StatusCode,
            Message = "Serverda xatolik yuz berdi. Iltimos, keyinroq urinib ko‘ring.",
            Detail = exception.Message
        };

        var json = JsonSerializer.Serialize(response);
        return context.Response.WriteAsync(json);
    }
}
