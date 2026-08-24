using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

namespace NamespaceToken;

public static class ItemName
{
    public static IResourceBuilder<ProjectResource> AddDatabaseTo(
        this IResourceBuilder<ProjectResource> project,
        IResourceBuilder<IResourceWithConnectionString> database)
        => project
            .WithEnvironment("database:provider", "postgresql")
            .WithEnvironment("database:connection-string", database)
            .WaitFor(database);

    public static IResourceBuilder<ProjectResource> AddMigration(
        this IResourceBuilder<ProjectResource> project,
        string section,
        bool initialize,
        bool migrate,
        bool testData)
        => project
            .WithEnvironment($"{section}:initialization:migrate", migrate.ToString().ToLowerInvariant())
            .WithEnvironment($"{section}:initialization:initialize", initialize.ToString().ToLowerInvariant())
            .WithEnvironment($"{section}:initialization:test-data", testData.ToString().ToLowerInvariant());

    public static IResourceBuilder<ProjectResource> AddMigrationForAll(
        this IResourceBuilder<ProjectResource> project,
        string sectionPrefix,
        bool initialize,
        bool migrate,
        bool testData,
        params string[] moduleNames)
    {
        foreach (var moduleName in moduleNames)
            project = project.AddMigration(
                $"{sectionPrefix}:{moduleName}",
                initialize,
                migrate,
                testData);

        return project;
    }
}
