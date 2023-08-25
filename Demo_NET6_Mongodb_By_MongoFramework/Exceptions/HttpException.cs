using System.Net;

namespace Demo_NET6_Mongodb_By_MongoFramework.Exceptions
{
    namespace HttpExceptions
    {
        public abstract class HttpException : Exception
        {
            public abstract int StatusCode { get; }
        }

        public class CustomHttpException : HttpException
        {
            public override int StatusCode { get; }
            public override string Message { get; }

            public CustomHttpException(HttpStatusCode statusCode, string message)
            {
                StatusCode = (int)statusCode;
                Message = message;
            }
        }

        public class BadRequestException : HttpException
        {
            public override int StatusCode { get { return (int)HttpStatusCode.BadRequest; } }
            public override string Message { get; }

            public BadRequestException()
            {
                Message = "Bad Request";
            }
            public BadRequestException(string message)
            {
                Message = message;
            }
        }

        public class MethodNotAllowedException : HttpException
        {
            public override int StatusCode { get { return (int)HttpStatusCode.MethodNotAllowed; } }
            public override string Message { get; }

            public MethodNotAllowedException()
            {
                Message = "Method not allowed";
            }
            public MethodNotAllowedException(string message)
            {
                Message = message;
            }
        }

        public class NotFoundException : HttpException
        {
            public override int StatusCode { get { return (int)HttpStatusCode.NotFound; } }
            public override string Message { get; }

            public NotFoundException()
            {
                Message = "Request Error";
            }
            public NotFoundException(string message)
            {
                Message = message;
            }
        }

        public class HttpInternalServerErrorException : HttpException
        {
            public override int StatusCode { get { return (int)HttpStatusCode.InternalServerError; } }
            public override string Message { get; }

            public Exception Ex { get; }
            public HttpInternalServerErrorException()
            {

            }
            public HttpInternalServerErrorException(string message)
            {
                Message = message;
            }
            public HttpInternalServerErrorException(string message, Exception ex)
            {
                Message = message;
                Ex = ex;
            }
        }

        public class UnauthorizedException : HttpException
        {
            public override int StatusCode { get { return (int)HttpStatusCode.Unauthorized; } }
            public override string Message { get; }

            public UnauthorizedException()
            {
                Message = "Unauthorized";
            }
            public UnauthorizedException(string message)
            {
                Message = message;
            }
        }
    }
}


