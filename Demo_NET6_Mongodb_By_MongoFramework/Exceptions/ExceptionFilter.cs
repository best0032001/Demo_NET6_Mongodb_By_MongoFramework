using Microsoft.AspNetCore.Mvc.Filters;

namespace Demo_NET6_Mongodb_By_MongoFramework.Exceptions;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ExceptionFilter : ExceptionFilterAttribute
{
    public ExceptionFilter()
    {

    }
    public override void OnException(ExceptionContext filterContext)
    {
    }
}
