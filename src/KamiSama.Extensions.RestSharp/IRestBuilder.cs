using RestSharp;

namespace KamiSama.Extensions.RestSharp;
public interface IRestBuilder
{
	IRestBuilder ForServiceUrl(string baseUrl, string relativePath);
	IRestBuilder AddParameter(string name, object? value, ParameterType parameterType = ParameterType.GetOrPost, bool encode = true);
    IRestBuilder AddQueryParameter(object queryParams);
    IRestBuilder AddUrlSegment(string name, object? value, bool encode = true);
    IRestBuilder AddFile(string filename, byte[] data);
    IRestBuilder AddHeader(string name, string value);
    IRestBuilder WithBody(object body, string contentType = "application/json");
	Task<T> GetAsync<T>(CancellationToken cancellationToken);
    Task<T> PostAsync<T>(CancellationToken cancellationToken);
	Task<T> PutAsync<T>(CancellationToken cancellationToken);
    Task DeleteAsync(CancellationToken cancellationToken);
    Task GetAsyncWithoutResponse(CancellationToken cancellationToken);
    Task PostAsyncWithoutResponse(CancellationToken cancellationToken);
    Task PutAsyncWithoutResponse(CancellationToken cancellationToken);
}
