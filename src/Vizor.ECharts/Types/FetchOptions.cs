namespace Vizor.ECharts;

public class FetchOptions
{
	/// <summary>
	/// The request method, e.g., "GET", "POST". The default is "GET". 
	/// </summary>
	public string? Method { get; set; }

	/// <summary>
	/// See https://developer.mozilla.org/en-US/docs/Glossary/Forbidden_header_name for a list of headers that are NOT allowed
	/// The Authorization HTTP header may be added to a request, but will be removed if the request is redirected cross-origin.
	/// 
	/// e.g.:  "Content-Type": "application/json"
	/// </summary>
	public Dictionary<string, string>? Headers { get; set; }

	/// <summary>
	/// The mode you want to use for the request, e.g., cors, no-cors, or same-origin.
	/// </summary>
	public string? Mode { get; set; }

	/// <summary>
	/// Controls what browsers do with credentials(cookies, HTTP authentication entries, and TLS client certificates). Must be one of the following strings:
	/// omit: Tells browsers to exclude credentials from the request, and ignore any credentials sent back in the response(e.g., any Set-Cookie header).
	/// same-origin: Tells browsers to include credentials with requests to same-origin URLs, and use any credentials sent back in responses from same-origin URLs.This is the default value.
	/// include: Tells browsers to include credentials in both same- and cross-origin requests, and always use any credentials sent back in responses.
	/// 
	/// Note: Credentials may be included in simple and "final" cross-origin requests, but should not be included in CORS preflight requests.
	/// </summary>
	public string? Credentials { get; set; }

	/// <summary>
	/// A string indicating how the request will interact with the browser's HTTP cache.
	/// The possible values, default, no-store, reload, no-cache, force-cache, and only-if-cached.
	/// See https://developer.mozilla.org/en-US/docs/Web/API/Request/cache for more details
	/// </summary>
	public string? Cache { get; set; }

	/// <summary>
	/// How to handle a redirect response:
	/// 
	/// follow: Automatically follow redirects.Unless otherwise stated the redirect mode is set to follow.
	/// error: Abort with an error if a redirect occurs.
	/// manual: Caller intends to process the response in another context.See WHATWG fetch standard for more information.
	/// </summary>
	public string? Redirect { get; set; }

	/// <summary>
	/// A string specifying the referrer of the request. This can be a same-origin URL, about:client, or an empty string.
	/// </summary>
	public string? Referrer { get; set; }

	/// <summary>
	/// Specifies the referrer policy to use for the request.
	/// May be one of no-referrer, no-referrer-when-downgrade, same-origin, origin, strict-origin, origin-when-cross-origin, strict-origin-when-cross-origin, or unsafe-url.
	/// </summary>
	public string? ReferrerPolicy { get; set; }

	/// <summary>
	/// Contains the subresource integrity value of the request (e.g., sha256-BpfBw7ivV8q2jLiT13fxDYAe2tJllusRSZ273h2nFSE=).
	/// </summary>
	public string? Integrity { get; set; }

	/// <summary>
	/// Specifies the priority of the fetch request relative to other requests of the same type. Must be one of the following strings:
	/// high: A high priority fetch request relative to other requests of the same type.
	/// low: A low priority fetch request relative to other requests of the same type.
	/// auto: Automatically determine the priority of the fetch request relative to other requests of the same type(default).
	/// </summary>
	public string? Priority { get; set; }
}
