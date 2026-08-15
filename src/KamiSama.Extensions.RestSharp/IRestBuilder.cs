using RestSharp;

namespace KamiSama.Extensions.RestSharp;

/// <summary>
/// Builds and executes one RestSharp request through a fluent API.
/// Start each request with <see cref="ForServiceUrl"/>, add the required request data, and then call an HTTP verb method.
/// </summary>
public interface IRestBuilder
{
	/// <summary>
	/// Starts a request by combining a service base URL with a relative resource path.
	/// Calling this method replaces any request previously configured on this builder.
	/// </summary>
	/// <param name="baseUrl">The absolute base URL of the remote service.</param>
	/// <param name="relativePath">The path of the resource relative to the service URL.</param>
	/// <returns>The same builder so request configuration can be chained.</returns>
	IRestBuilder ForServiceUrl(string baseUrl, string relativePath);
	/// <summary>
	/// Adds a RestSharp parameter to the current request.
	/// </summary>
	/// <param name="name">The parameter name.</param>
	/// <param name="value">The parameter value.</param>
	/// <param name="parameterType">The location or role of the parameter.</param>
	/// <param name="encode">Whether RestSharp should URL-encode the value.</param>
	/// <returns>The same builder so request configuration can be chained.</returns>
	IRestBuilder AddParameter(string name, object? value, ParameterType parameterType = ParameterType.GetOrPost, bool encode = true);
	/// <summary>
	/// Adds the public properties of an object as query parameters on the current request.
	/// </summary>
	/// <param name="queryParams">The object whose public properties supply query parameter names and values.</param>
	/// <returns>The same builder so request configuration can be chained.</returns>
    IRestBuilder AddQueryParameter(object queryParams);
	/// <summary>
	/// Adds a value for a named URL segment in the current request path.
	/// </summary>
	/// <param name="name">The URL segment name.</param>
	/// <param name="value">The value that replaces the named segment.</param>
	/// <param name="encode">Whether RestSharp should URL-encode the value.</param>
	/// <returns>The same builder so request configuration can be chained.</returns>
    IRestBuilder AddUrlSegment(string name, object? value, bool encode = true);
	/// <summary>
	/// Adds an in-memory file to the current multipart request.
	/// </summary>
	/// <param name="filename">The form field and file name sent to the remote service.</param>
	/// <param name="data">The complete file content.</param>
	/// <returns>The same builder so request configuration can be chained.</returns>
    IRestBuilder AddFile(string filename, byte[] data);
	/// <summary>
	/// Adds an HTTP header to the current request.
	/// </summary>
	/// <param name="name">The header name.</param>
	/// <param name="value">The header value.</param>
	/// <returns>The same builder so request configuration can be chained.</returns>
    IRestBuilder AddHeader(string name, string value);
	/// <summary>
	/// Adds an object body with the specified content type to the current request.
	/// </summary>
	/// <param name="body">The object RestSharp serializes as the request body.</param>
	/// <param name="contentType">The media type of the request body.</param>
	/// <returns>The same builder so request configuration can be chained.</returns>
    IRestBuilder WithBody(object body, string contentType = "application/json");
	/// <summary>
	/// Sends the current request with GET and deserializes a successful response body as <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T">The expected response body type.</typeparam>
	/// <param name="cancellationToken">The token used to cancel the HTTP operation.</param>
	/// <returns>The deserialized response body.</returns>
	Task<T> GetAsync<T>(CancellationToken cancellationToken);
	/// <summary>
	/// Sends the current request with POST and deserializes a successful response body as <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T">The expected response body type.</typeparam>
	/// <param name="cancellationToken">The token used to cancel the HTTP operation.</param>
	/// <returns>The deserialized response body.</returns>
    Task<T> PostAsync<T>(CancellationToken cancellationToken);
	/// <summary>
	/// Sends the current request with PUT and deserializes a successful response body as <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T">The expected response body type.</typeparam>
	/// <param name="cancellationToken">The token used to cancel the HTTP operation.</param>
	/// <returns>The deserialized response body.</returns>
	Task<T> PutAsync<T>(CancellationToken cancellationToken);
	/// <summary>
	/// Sends the current request with DELETE and completes when the remote service returns a successful response.
	/// </summary>
	/// <param name="cancellationToken">The token used to cancel the HTTP operation.</param>
	/// <returns>A task representing the HTTP operation.</returns>
    Task DeleteAsync(CancellationToken cancellationToken);
	/// <summary>
	/// Sends the current request with GET without deserializing a response body.
	/// </summary>
	/// <param name="cancellationToken">The token used to cancel the HTTP operation.</param>
	/// <returns>A task representing the HTTP operation.</returns>
    Task GetAsyncWithoutResponse(CancellationToken cancellationToken);
	/// <summary>
	/// Sends the current request with POST without deserializing a response body.
	/// </summary>
	/// <param name="cancellationToken">The token used to cancel the HTTP operation.</param>
	/// <returns>A task representing the HTTP operation.</returns>
    Task PostAsyncWithoutResponse(CancellationToken cancellationToken);
	/// <summary>
	/// Sends the current request with PUT without deserializing a response body.
	/// </summary>
	/// <param name="cancellationToken">The token used to cancel the HTTP operation.</param>
	/// <returns>A task representing the HTTP operation.</returns>
    Task PutAsyncWithoutResponse(CancellationToken cancellationToken);
}
