# `KamiSama.Chassis.HttpExceptions`

## `KamiSama.Chassis.HttpExceptions`

### `HttpExceptionBase`
Base exception for HTTP-aware failures. Carries status code, localization metadata, and optional extended properties.

### `StatusCode`
Abstract HTTP status code.

### `TryFormatString(string message, params object?[] args)`
Safely formats a message key with arguments.

```csharp
using KamiSama.Chassis.HttpExceptions;

throw new BadRequestException("InvalidInput", "email");
```

## `KamiSama.Chassis.HttpExceptions`

### `BadRequestException`
400 client input error.

No public methods beyond constructors and `StatusCode`.

```csharp
throw new BadRequestException("ValidationFailed", "email");
```

## `KamiSama.Chassis.HttpExceptions`

### `ConflictException`
409 state conflict error.

No public methods beyond constructors and `StatusCode`.

```csharp
throw new ConflictException("ConcurrencyConflict");
```

## `KamiSama.Chassis.HttpExceptions`

### `AlreadyExistsException`
Specialized conflict for duplicate entities.

### `AlreadyExistsException<TEntity>`
Generic duplicate-entity shortcut.

No public methods beyond constructors.

```csharp
throw new AlreadyExistsException<User>(request.Email, "email");
```

## `KamiSama.Chassis.HttpExceptions`

### `NotFoundException`
404 missing-entity error.

### `NotFoundException<TEntity>`
Generic missing-entity shortcut.

No public methods beyond constructors.

```csharp
throw new NotFoundException<User>(id);
```

## `KamiSama.Chassis.HttpExceptions`

### `ForbiddenException`
403 authorization failure.

## `KamiSama.Chassis.HttpExceptions`

### `UnAuthorizedException`
401 authentication/authorization failure.

## `KamiSama.Chassis.HttpExceptions`

### `PaymentRequiredException`
402 payment-related error.

## `KamiSama.Chassis.HttpExceptions`

### `UnProcessableEntityException`
422 semantic validation error.

## `KamiSama.Chassis.HttpExceptions`

### `ServiceUnavailableException`
503 external dependency or service outage.

## `KamiSama.Chassis.HttpExceptions`

### `InvalidOperationHttpException`
500 invalid operation wrapped as an HTTP exception.

## `KamiSama.Chassis.HttpExceptions`

### `NotImplementedHttpException`
501 unsupported implementation branch.

## `KamiSama.Chassis.HttpExceptions`

### `NotSupportedHttpException`
500 unsupported operation in current source.

## `KamiSama.Chassis.HttpExceptions`

### `GoneException`
Returns `401` in current source, despite the conventional meaning of HTTP 410.

These exception types expose constructors and `StatusCode` only; they are intended to be thrown, not extended with behavior.

```csharp
throw new ServiceUnavailableException("PaymentGateway");
```

# `KamiSama.Chassis.ProblemDetails`

## `KamiSama.Chassis.ProblemDetails`

### `IProblemDetailsDataProvider`
Converts exceptions into ASP.NET `ProblemDetails`.

### `ConvertExceptionToProblemDetails(Exception exception)`
Builds a `ProblemDetails` response.

```csharp
using KamiSama.Chassis.ProblemDetails;

var details = provider.ConvertExceptionToProblemDetails(exception);
```

## `KamiSama.Chassis.ProblemDetails`

### `KamiSamaProblemDetailsOptions`
Configuration DTO for provider creation and localization.

### `UseDefaultProblemDetailsProvider()`
Uses `KamiSamaProblemDetailsProvider`.

### `UseProblemDetailsProvider(Func<IServiceProvider, IProblemDetailsDataProvider> providerFunc)`
Supplies a custom provider factory.

### `UseResourceLocalizer<ResourceType>()`
Uses an `IStringLocalizer` for a resource type.

```csharp
using KamiSama.Chassis.ProblemDetails;

var options = new KamiSamaProblemDetailsOptions()
    .UseDefaultProblemDetailsProvider()
    .UseResourceLocalizer<MyResource>();
```

## `KamiSama.Chassis.ProblemDetails`

### `KamiSamaProblemDetailsProvider`
Default provider that converts `HttpExceptionBase` instances into localized `ProblemDetails`.

### `ConvertExceptionToProblemDetails(Exception exception)`
Maps exceptions to `ProblemDetails`, wrapping non-HTTP exceptions in `InvalidOperationHttpException`.

```csharp
using KamiSama.Chassis.ProblemDetails;

var details = provider.ConvertExceptionToProblemDetails(new NotFoundException<User>(42));
```

## `KamiSama.Chassis.ProblemDetails`

### `ProblemDetailsExceptionFilter`
MVC exception filter that delegates to `IProblemDetailsDataProvider`.

### `OnException(ExceptionContext context)`
Replaces the response with an `ObjectResult` wrapping `ProblemDetails`.

```csharp
builder.Services.AddControllers()
    .AddExceptionFilterForProblemDetails();
```

## `KamiSama.Chassis.ProblemDetails`

### `ServiceCollectionExtension`
MVC registration helper for the problem-details pipeline.

### `AddExceptionFilterForProblemDetails(this IMvcBuilder builder, Action<KamiSamaProblemDetailsOptions>? config = null)`
Registers options, provider, and the exception filter in one call.

```csharp
using KamiSama.Chassis.ProblemDetails;

services.AddControllers()
    .AddExceptionFilterForProblemDetails(opt => opt.UseDefaultProblemDetailsProvider());
```

# `KamiSama.Chassis.Commons.Repositories`

## `KamiSama.Chassis.Commons.Repositories`

### `IAddableRepository<TEntity>`
Async add capability.

### `AddAsync`
Adds an entity.

## `KamiSama.Chassis.Commons.Repositories`

### `IUpdatableRepository<TEntity>`
Async update capability.

### `UpdateAsync`
Updates an entity.

## `KamiSama.Chassis.Commons.Repositories`

### `IDeletableRepository<TEntity>`
Async delete capability.

### `DeleteAsync`
Deletes an entity.

## `KamiSama.Chassis.Commons.Repositories`

### `ILookupByIdRepository<TEntity, TKey>`
Find/exists-by-id capability.

### `FindByIdAsync`
Returns the entity or `null`.

### `ExistsByIdAsync`
Checks existence by key.

## `KamiSama.Chassis.Commons.Repositories`

### `ILookupByNameRepository<TEntity>`
Find/exists-by-name capability.

### `FindByNameAsync`
Returns the entity or `null`.

### `ExistsByNameAsync`
Checks existence by name.

## `KamiSama.Chassis.Commons.Repositories`

### `IListingRepository<TEntity, TSearchModel, TPagedResult>`
Paged listing repository contract.

### `ListAsync`
Returns a paged result.

### `CountAsync`
Returns the total item count for a search model.

## `KamiSama.Chassis.Commons.Repositories`

### `IListingRepository<TEntity, TSearchModel>`
Shortcut for `PagedResult<TEntity>`.

## `KamiSama.Chassis.Commons.Repositories`

### `IGenericRepository<TEntity, TSearchModel, TPagedResult>`
Composes add, update, delete, and list contracts.

## `KamiSama.Chassis.Commons.Repositories`

### `IGenericRepository<TEntity, TSearchModel>`
Shortcut generic repository based on `PagedResult<TEntity>`.

```csharp
using KamiSama.Chassis.Commons.Repositories;
using KamiSama.Extensions.Paging;

public interface IUserRepository : IGenericRepository<User, SearchModel>, ILookupByIdRepository<User, int> {}
```

## `KamiSama.Chassis.Commons.Repositories`

### `GenericRepository<TEntity, TSearchModel, TDbContext>`
Base EF Core repository for paged listing over `PagedResult<TEntity>`.

Derived types implement:

- `ApplySearchModel`

## `KamiSama.Chassis.Commons.Repositories`

### `GenericRepository<TEntity, TSearchModel, TDbContext, TPagedResult>`
Base EF Core repository for custom paged result types.

### `ListAsync`
Applies the search model then creates the result.

### `CountAsync`
Counts after applying the search model.

```csharp
using KamiSama.Chassis.Commons.Repositories;
using KamiSama.Extensions.Paging;

public sealed class UserRepository(AppDbContext context)
    : GenericRepository<User, SearchModel, AppDbContext>(context), ILookupByIdRepository<User, int>
{
    protected override IQueryable<User> ApplySearchModel(IQueryable<User> query, SearchModel searchModel)
        => query;

    public Task<User?> FindByIdAsync(int id, CancellationToken cancellationToken)
        => FindAsync(x => x.Id == id, cancellationToken);

    public Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken)
        => AnyAsync(x => x.Id == id, cancellationToken);
}
```

# `KamiSama.Chassis.Commons.Features`

## `KamiSama.Chassis.Commons.Features`

### `IAddFeature<TAddRequest, TEntityDto>`
Add use-case abstraction.

### `AddAsync`
Creates an entity from a request DTO and returns a DTO.

## `KamiSama.Chassis.Commons.Features`

### `IUpdateFeature<TEntityDto, TKey>`
Update use-case abstraction.

### `UpdateAsync`
Updates an entity by key.

## `KamiSama.Chassis.Commons.Features`

### `IDeleteFeature<TKey>`
Delete use-case abstraction.

### `DeleteAsync`
Deletes an entity by key.

## `KamiSama.Chassis.Commons.Features`

### `IFindByIdFeature<TEntityDto, TKey>`
Lookup-by-id use-case abstraction.

### `FindByIdAsync`
Returns a DTO by key.

## `KamiSama.Chassis.Commons.Features`

### `IFindByNameFeature<TEntityDto>`
Lookup-by-name use-case abstraction.

### `FindByNameAsync`
Returns a DTO by name.

## `KamiSama.Chassis.Commons.Features`

### `IExistsByIdFeature<TKey>`
Existence-by-id use-case abstraction.

### `ExistsByIdAsync`
Checks existence by key.

## `KamiSama.Chassis.Commons.Features`

### `IExistsByNameFeature`
Existence-by-name use-case abstraction.

### `ExistsByNameAsync`
Checks existence by name.

## `KamiSama.Chassis.Commons.Features`

### `IListFeature<TEntityDto, TSearchModel, TPageResult>`
Paged list use-case abstraction.

### `ListAsync`
Returns a paged DTO result.

## `KamiSama.Chassis.Commons.Features`

### `IListFeature<TEntityDto, TSearchModel>`
Shortcut based on `PagedResult<TEntityDto>`.

```csharp
using KamiSama.Chassis.Commons.Features;
using KamiSama.Extensions.Paging;

public interface IListUsersFeature : IListFeature<UserDto, SearchModel> {}
```

## `KamiSama.Chassis.Commons.Features`

### `GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>`
Base implementation for create flows.

### `AddAsync`
Checks duplicates, converts the request, persists, and converts the result.

## `KamiSama.Chassis.Commons.Features`

### `GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>`
Base implementation for update flows.

### `UpdateAsync`
Loads by id, checks duplicates, patches the entity, and saves.

## `KamiSama.Chassis.Commons.Features`

### `GenericDeleteFeature<TEntity, TRepository, TKey>`
Base implementation for delete flows.

### `DeleteAsync`
Loads by id, checks `CanBeDeletedAsync`, and deletes.

## `KamiSama.Chassis.Commons.Features`

### `GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>`
Base implementation for find-by-id flows.

### `FindByIdAsync`
Loads by id or throws `NotFoundException<TEntity>`, then maps to DTO.

## `KamiSama.Chassis.Commons.Features`

### `GenericFindByNameFeature<TEntity, TEntityDto, TRepository>`
Base implementation for find-by-name flows.

### `FindByNameAsync`
Loads by name or throws `NotFoundException<TEntity>`, then maps to DTO.

## `KamiSama.Chassis.Commons.Features`

### `GenericExistsByIdFeature<TEntity, TRepository, TKey>`
Base implementation for existence checks by id.

### `ExistsByIdAsync`
Delegates to the repository.

## `KamiSama.Chassis.Commons.Features`

### `GenericExistsByNameFeature<TEntity, TRepository>`
Base implementation for existence checks by name.

### `ExistsByNameAsync`
Delegates to the repository.

## `KamiSama.Chassis.Commons.Features`

### `GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository, TPagedResult, TRepositoryPagedResult>`
Base listing feature for custom paged result types.

### `ListAsync`
Delegates to the repository and converts the result shape.

## `KamiSama.Chassis.Commons.Features`

### `GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>`
Base listing feature for standard `PagedResult<TEntityDto>`.

### `ListAsync`
Loads a repository page and maps it to DTOs.

## `KamiSama.Chassis.Commons.Features`

### `FeatureDefinitionBase<TEntity, TEntityDto, TAddRequest, TUpdateRequest, TRepository, TSearchModel, TKey>`
Type-mapping convenience shell that exposes nested base classes for list, add, update, delete, and find-by-id features.

Nested public base classes:

- `ListFeatureBase`
- `AddFeatureBase`
- `UpdateFeatureBase`
- `DeleteFeatureBase`
- `FindByIdFeatureBase`
- `ExistsByIdFeatureBase`

```csharp
using KamiSama.Chassis.Commons.Features;
using KamiSama.Chassis.Commons.Repositories;
using KamiSama.Extensions.Paging;

public sealed class UserFeatureDefinition
    : FeatureDefinitionBase<User, UserDto, AddUserRequest, UpdateUserRequest, IUserRepository, SearchModel, int>
{
    public abstract class BaseList(IUserRepository repository) : ListFeatureBase(repository)
    {
        protected override Task<UserDto> ConvertToDto(User entity, CancellationToken cancellationToken)
            => Task.FromResult(new UserDto(entity.Id, entity.Name));
    }
}
```
