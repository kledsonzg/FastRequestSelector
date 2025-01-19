using Aspose.Html;
using Aspose.Html.Dom;

namespace KledsonZG.FastRequestSelector;

/// <summary>
/// Class <c>Request</c> provide static methods to get HTML Elements without any instance.
/// </summary>
public static class Request
{
    /// <summary>
    /// Method <c>GetElements</c> do a HTTP Request (GET) to the <c>url</c> and return all elements based in the CSS Rule (<c>cssSelector</c>).
    /// </summary>
    public static HTMLElement[] GetElements(string url, string cssSelector)
    {
        // Requisição HTTP simples.
        var httpClient = new HttpClient();
        var htmlResult = httpClient.GetStringAsync(url).Result;

        // Criação da instância com
        var document = new HTMLDocument(htmlResult, ".");
        var nodes = document.QuerySelectorAll(cssSelector);

        HTMLElement[] elements = nodes.Where(selector => selector is HTMLElement).Select(selector => (HTMLElement) selector).ToArray();   
        return elements;
    }
    
    /// <summary>
    /// Method <c>GetElementAt</c> do a HTTP Request (GET) to the <c>url</c> and return an element based in the CSS Rule at <c>index</c> position.
    /// </summary>
    public static HTMLElement? GetElementAt(string url, string cssSelector, int index)
    {
        var nodes = GetElements(url, cssSelector);

        return (index < nodes.Length && index >= 0) ? nodes[index] : null;
    }  

    /// <summary>
    /// Method <c>GetElement</c> do a HTTP Request (GET) to the <c>url</c> and return the first element based in the CSS Rule.
    /// </summary>
    public static HTMLElement? GetFirstElement(string url, string cssSelector) => GetElementAt(url, cssSelector, 0);
}
