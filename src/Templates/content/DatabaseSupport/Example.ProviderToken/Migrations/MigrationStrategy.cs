namespace Example.ProviderToken.Migrations;

public static class MigrationStrategy
{
    // Add migrations to this provider project so each provider owns its migration history.
    public const string AddCommand = "dotnet ef migrations add <Name> --project .";
}
