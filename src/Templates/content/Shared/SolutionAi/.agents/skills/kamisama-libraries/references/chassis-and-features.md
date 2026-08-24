# Chassis And Features Snapshot

- `KamiSama.Chassis.HttpExceptions`: use typed exceptions such as `BadRequestException`, `ConflictException`, `AlreadyExistsException<TEntity>`, and `NotFoundException<TEntity>`.
- `KamiSama.Chassis.ProblemDetails`: configure `KamiSamaProblemDetailsOptions` and `AddExceptionFilterForProblemDetails`.
- `KamiSama.Chassis.Commons.Repositories`: compose `IGenericRepository<TEntity,TSearchModel>` with lookup contracts; derive EF Core implementations from `GenericRepository<TEntity,TSearchModel,TDbContext>`.
- `KamiSama.Chassis.Commons.Features`: use operation-specific `IAddFeature`, `IUpdateFeature`, `IDeleteFeature`, `IFindByIdFeature`, and `IListFeature` contracts.
- `FeatureDefinitionBase<TEntity,TEntityDto,TAddRequest,TUpdateRequest,TRepository,TSearchModel,TKey>` exposes nested list, add, update, delete, find, and exists bases.

Use one service per operation. Keep business rules in bounded-context services, persistence in repositories, and cross-context workflows in panel Core orchestration.
