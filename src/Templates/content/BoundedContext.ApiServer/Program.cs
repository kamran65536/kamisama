using KamiSama.Repositories.Initialization;

namespace Example.ApiServer;

public class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var dataInitializationOptions = new DataInitializationOptions
		{
			Migrate = builder.Configuration.GetValue("ConfigSection:initialization:migrate", false),
			InitializeData = builder.Configuration.GetValue("ConfigSection:initialization:initialize", false),
			InitializeTestData = builder.Configuration.GetValue("ConfigSection:initialization:test-data", false)
		};
		var connectionProvider = builder.Configuration["ConfigSection:database:provider"] ?? throw new ArgumentException("provider is not found.");
		var connectionString = builder.Configuration["ConfigSection:database:connectionString"] ?? throw new ArgumentException("Connection string is not found.");

		// Add services to the container.

		builder.Services.Configure<RouteOptions>(opt => opt.LowercaseUrls = true);
		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		///#if (AddSamples)
		builder.Services.AddSomeContext(connectionString, connectionProvider);
		///#endif
		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();
		app.MapControllers();

		await app.TryInitializeSomeContextAsync(dataInitializationOptions, CancellationToken.None);

		app.Run();
	}
}
