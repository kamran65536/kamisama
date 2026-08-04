//#if (IncludeEntities)
global using ExampleCore.Entities;
//#endif
global using KamiSama.Extensions.DependencyInjection;
//#if (IncludeDatabase)
global using ExampleCore.Repositories.Database;
global using KamiSama.Chassis.Commons.Repositories;
global using KamiSama.Extensions.Paging;
global using Microsoft.EntityFrameworkCore;
global using System.Diagnostics.CodeAnalysis;
//#endif
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ExampleCore.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
