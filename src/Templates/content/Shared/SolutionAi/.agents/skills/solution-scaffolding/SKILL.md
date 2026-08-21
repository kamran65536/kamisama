# Solution Scaffolding

1. Run `dotnet sln list` or inspect the `.slnx` file and project references.
2. Run `dotnet new list kamisama` and inspect template help before generation.
3. Generate into an explicit path and add projects to the solution only when the template has not already done so.
4. Keep `props.xml` opt-in and pass the layout-correct `PropsPath` to project templates.
5. Build the smallest generated solution or project and inspect configuration placeholders before runtime use.
