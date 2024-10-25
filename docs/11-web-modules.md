# 11. Web Modules
Web Modules are the a way to simplify the process of building web applications and web apis.
To do so, a class __ExtendedWebApplicationBuilder__ is added which supports modular addition of features.

The old web api program would be:
```csharp
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
            
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
```

While the new approach would be:
```csharp
internal class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args).Extend();

		var app = builder
			.AddHttpsRedirection()
			.AddAuthorization()
			.AddSwagger(addEndPointInProduction: false)
			.AddControllers()
			.Build();

		app.Run();
	}
}
```

You still have all functionalities of a WebApplicationBuilder:
```csharp
internal class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args).Extend();

		// using the traditional way of building application
		builder.Services.AddControllers();

		var app = builder
			.AddHttpsRedirection()
			.AddAuthorization()
			.AddSwagger(addEndPointInProduction: false)
			.Build();

		// map controllers in the traditional way
		app.MapControllers();

		app.Run();
	}
}
```