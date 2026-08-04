using KamiSama.Extensions;
using KamiSama.Extensions.DependencyInjection;
using KamiSama.Extensions.RestSharp.Exceptions;
using RestSharp;

namespace KamiSama.Extensions.RestSharp;

[AutoInjectScoped<IRestBuilder>]
internal class RestBuilder(IRestClient client) : IRestBuilder
{
	private RestRequest? nullableRequest;
	private RestRequest Request => nullableRequest ?? throw new InvalidOperationException("Service URL must be set before making a request.");
	public IRestBuilder ForServiceUrl(string baseUrl, string relativePath)
	{
		nullableRequest = new RestRequest(baseUrl.TrimEnd('/') + "/" + relativePath.TrimStart('/'));

		return this;
	}

	public IRestBuilder AddQueryParameter(object queryParams)
	{
		//TODO fix it later
		Request.AddObject(queryParams);
		return this;
	}
	public IRestBuilder AddUrlSegment(string name, object? value, bool encode)
		=> AddParameter(name, value, ParameterType.UrlSegment, encode);

	public IRestBuilder AddParameter(string name, object? value, ParameterType parameterType, bool encode)
    {
        Request.AddParameter(Parameter.CreateParameter(name, value, parameterType, encode));

		return this;
    }

    public IRestBuilder AddHeader(string name, string value)
	{
		Request.AddHeader(name, value);

		return this;
	}
    public IRestBuilder AddFile(string filename, byte[] data)
    {
		Request.AddFile(filename, data, filename);

		return this;
    }
    public IRestBuilder WithBody(object body, string contentType)
	{
		Request.AddBody(body, contentType);

		return this;
	}

	public async Task<T> GetAsync<T>(CancellationToken cancellationToken)
	{
		var response = await client.GetAsync(Request, cancellationToken);
		if (response.IsSuccessful)
		{
			if (response.Content == null)
				throw new InvalidResponseFromServerException("Invalid Content");
			
			return response.Content.DeserializeFromJson<T>(opt => opt.PropertyNameCaseInsensitive = true) ?? throw new InvalidResponseFromServerException();
		}

		throw response.ResponseStatus switch
		{
			ResponseStatus.TimedOut => new RequestTimedOutException(),
			_ => new InvalidResponseFromServerException(),
		};
	}
    public async Task<T> PutAsync<T>(CancellationToken cancellationToken)
    {
        var response = await client.PutAsync(Request, cancellationToken);
        if (response.IsSuccessful)
        {
            if (response.Content == null)
                throw new InvalidResponseFromServerException("InvalidContent");

            return response.Content.DeserializeFromJson<T>(opt => opt.PropertyNameCaseInsensitive = true) ?? throw new InvalidResponseFromServerException();
        }

        throw response.ResponseStatus switch
        {
            ResponseStatus.TimedOut => new RequestTimedOutException(),
            _ => new InvalidResponseFromServerException(),
        };
    }
    public async Task<T> PostAsync<T>(CancellationToken cancellationToken)
	{
		var response = await client.PostAsync(Request, cancellationToken);
		if (response.IsSuccessful)
		{
			if (response.Content == null)
				throw new InvalidResponseFromServerException("InvalidContent");

			return response.Content.DeserializeFromJson<T>(opt => opt.PropertyNameCaseInsensitive = true) ?? throw new InvalidResponseFromServerException();
		}

		throw response.ResponseStatus switch
		{
			ResponseStatus.TimedOut => new RequestTimedOutException(),
			_ => new InvalidResponseFromServerException(),
		};
	}
    public async Task DeleteAsync(CancellationToken cancellationToken)
    {
        var response = await client.DeleteAsync(Request, cancellationToken);

        if (!response.IsSuccessful)
            throw response.ResponseStatus switch
            {
                ResponseStatus.TimedOut => new RequestTimedOutException(),
                _ => new InvalidResponseFromServerException(),
            };
    }
    public async Task GetAsyncWithoutResponse(CancellationToken cancellationToken)
	{
		var response = await client.GetAsync(Request, cancellationToken);

		if (!response.IsSuccessful)
			throw response.ResponseStatus switch
			{
				ResponseStatus.TimedOut => new RequestTimedOutException(),
				_ => new InvalidResponseFromServerException(),
			};
	}

	public async Task PostAsyncWithoutResponse(CancellationToken cancellationToken)
	{
		var response = await client.PostAsync(Request, cancellationToken);

		if (!response.IsSuccessful)
			throw response.ResponseStatus switch
			{
				ResponseStatus.TimedOut => new RequestTimedOutException(),
				_ => new InvalidResponseFromServerException(),
			};
	}
	public async Task PutAsyncWithoutResponse(CancellationToken cancellationToken)
	{
        var response = await client.PutAsync(Request, cancellationToken);

        if (!response.IsSuccessful)
            throw response.ResponseStatus switch
            {
                ResponseStatus.TimedOut => new RequestTimedOutException(),
                _ => new InvalidResponseFromServerException(),
            };
    }
}
