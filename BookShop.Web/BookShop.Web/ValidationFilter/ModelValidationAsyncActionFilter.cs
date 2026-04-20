using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace BookShop.Web.ValidationFilter;

public class ModelValidationAsyncActionFilter(IServiceProvider serviceProvider, IOptions<ApiBehaviorOptions> apiBehaviorOptions)
    : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Do not validate on HTTP GET and DELETE requests.
        if (context.HttpContext.Request.Method == "DELETE" || context.HttpContext.Request.Method == "GET")
        {
            await next();
            return;
        }

        foreach (var (_, value) in context.ActionArguments)
        {
            if (value is null)
                continue;

            await ValidateAsync(value, context);
        }

        if (!context.ModelState.IsValid)
        {
            context.Result = apiBehaviorOptions.Value.InvalidModelStateResponseFactory(context);
            return;
        }

        await next();
    }

    private async Task ValidateAsync(object value, ActionExecutingContext context)
    {
        var validator = (IValidator?)serviceProvider.GetService(typeof(IValidator<>).MakeGenericType(value.GetType()));

        if (validator == null)
            return;

        var result = await validator.ValidateAsync(new ValidationContext<object>(value));
        result.AddToModelState(context.ModelState);
    }
}
