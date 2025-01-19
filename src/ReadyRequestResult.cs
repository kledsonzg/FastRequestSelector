using System.Net.Http.Headers;
using Aspose.Html;

namespace KledsonZG.FastRequestSelector
{
    public class ReadyRequestResult
    {
        public ReadyRequest ReadyRequest { get; }
        public HTMLDocument Document { get; }
        public HTMLElement[] Elements { get; }
        public HttpResponseHeaders ResponseHeaders { get; }
        public System.Net.HttpStatusCode StatusCode { get; }
        
        public ReadyRequestResult(ReadyRequest readyRequest, HTMLDocument document, HTMLElement[] elements, HttpResponseHeaders responseHeaders, System.Net.HttpStatusCode statusCode)
        {
            ReadyRequest = readyRequest;
            Document = document;
            Elements = elements;
            ResponseHeaders = responseHeaders;
            StatusCode = statusCode;
        }

        public string ContentType
        {
            get
            {
                if(!ResponseHeaders.TryGetValues("Content-Type", out IEnumerable<string>? values) )
                    return string.Empty;
                if(values is null)
                    return string.Empty;
                
                return string.Join("; ", values);
            }
        }
    }
}