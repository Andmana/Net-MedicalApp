using System;

namespace Med_341A.Middlewares;

public class SessionMiddleware
{
    private readonly RequestDelegate _next;

    public SessionMiddleware(RequestDelegate next)
    {
        this._next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Session.GetInt32("IdUser") == null &&
            !(context.Request.Path.Value.Contains("/") || context.Request.Path.Value.Contains("/Auth") || context.Request.Path.Value.Contains("/ResetPassword") || context.Request.Path.Value.Contains("/Register")))
        {
            context.Response.Redirect("/");
            return;
        }

        await _next(context);
    }
}
