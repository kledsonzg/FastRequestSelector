using System.Text;
using Aspose.Html;

namespace KledsonZG.FastRequestSelector
{
    public class ReadyRequest
    {       
        private static HttpMethod[] _noBodyHttpMethods = [HttpMethod.Get, HttpMethod.Head, HttpMethod.Options, HttpMethod.Trace];

        public HttpMethod Method { get; set; } = HttpMethod.Get;
        public Dictionary<string, string[]> Headers = new();
        public string MediaType { get; set; } = "text/plain";
        public string Url { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public ReadyRequest(string url)
        {
            Url = url;
        }

        public ReadyRequest(string url, HttpMethod method)
        {
            Url = url;
            Method = method;
        }

        public async Task<ReadyRequestResult> GetResult(string cssSelector)
        {
            var client = new HttpClient();
            
            HttpRequestMessage requestMessage = new(Method, Url);
            if(!_noBodyHttpMethods.Contains(Method))
                requestMessage.Content = new StringContent(Content, Encoding.UTF8, MediaType);
            
            foreach(var key in Headers.Keys)
                requestMessage.Headers.Add(key, Headers[key] );
            
            Logger.Log($"Request Headers Count: {requestMessage.Headers.Count()}");

            foreach(var KeyValuePair in requestMessage.Headers)
                Logger.Log($"{KeyValuePair.Key} : {KeyValuePair.Value}");
            
            var requestResult = await client.SendAsync(requestMessage);
            string content = await requestResult.Content.ReadAsStringAsync();

            var document = new HTMLDocument(content, ".");
            HTMLElement[] elements  = document.QuerySelectorAll(cssSelector).Where(selector => selector is HTMLElement).Select(selector => (HTMLElement) selector).ToArray();

            return new ReadyRequestResult(this, document, elements, requestResult.Headers, requestResult.StatusCode);
        }
        public async Task<ReadyRequestResult> GetResult() => await GetResult("*");
    }
}