using System;
using System.Net;
using HalClient.Net5.Parser;

namespace HalClient.Net5
{
    [Serializable]
    public class HalHttpRequestException : Exception
    {
#if REQUIRES_EXCEPTION_SERIALIZATION_CTOR
        protected HalHttpRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
#endif

        public HalHttpRequestException(HttpStatusCode statusCode, string reason, IRootResourceObject resource = null)
            : base($"{(int)statusCode} ({reason})")
        {
            StatusCode = statusCode;
            Resource = resource;
        }

        public HttpStatusCode StatusCode { get; }
        public IRootResourceObject Resource { get; }
    }
}