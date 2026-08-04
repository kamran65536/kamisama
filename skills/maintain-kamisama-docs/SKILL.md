---
name: maintain-kamisama-docs
description: Use when Codex needs to add, update, review, or regenerate developer-focused MkDocs API documentation for KamiSama.Extensions packages, namespaces, types, constructors, methods, properties, fields, events, enum members, operators, delegates, examples, backlinks, package install commands, or version placeholders.
---

# Maintain KamiSama Docs

Maintain docs as developer guidance, not symbol inventory. A reader should understand what the API is for, when to use it, what inputs and outputs mean, and how to call or implement it.

## Source And Version

- MkDocs root: `docs`.
- Content root: `docs/content`.
- API docs root: `docs/content/api`.
- Generator: `docs/tools/ApiDocGenerator`.
- Canonical online docs path: `https://gitlab.com/kamran65536/KamiSama/-/tree/master/docs/content`.
- Use `{{ version }}` in documentation templates and examples that describe package version text.
- Package install command template:

```shell
dotnet add package <PackageId> --version {{ version }}
```

## Documentation Shape

Package pages must include:

- A 2-3 line description of what the package does and why a developer would install it.
- Version text using `{{ version }}` in templates or the resolved generated version in built docs.
- Install command.
- Namespace and type links.
- Backlink to the package index.

Namespace pages must include:

- A short description of the namespace purpose when available.
- Links to contained types.
- Backlink to the package page.

Type pages must include:

- A 2-3 line purpose description.
- Declaration and source link.
- Backlinks: type -> namespace -> package -> package index.
- Constructors on the type page, with parameter tables.
- Member links.
- Class-level examples for framework or pattern types.

Member pages must include:

- Declaration and source link.
- Backlinks: member -> type -> namespace -> package.
- A developer-understandable description of behavior.
- Parameter table for methods, indexers, and operators.
- Return table for non-void methods and operators.
- Value/details table for properties, fields, events, and enum members.
- Usage example when practical.
- The exact fallback sentence `No concise standalone example is available yet.` only when a safe example cannot be derived.

## Developer-Understandable Content

Prefer descriptions that answer:

- What problem does this package/type/member solve?
- When should a developer use it?
- What does the base class or framework code already do?
- What must the caller or implementer provide?
- What happens in the lifecycle or execution flow?
- What errors or caveats matter?

Avoid empty phrases such as:

- `Provides the X API.`
- `Runs the X operation.`
- `Use it with the surrounding package APIs.`

Replace them with behavior. For example, `GenericAddFeature.AddAsync` should explain that it checks duplicates, converts the request to an entity, persists through the repository, converts the entity to a DTO, and returns it.

## Examples

Examples must be honest, concise, and aligned with current source. Prefer examples from generated docs, source, tests, or skill references. Use generated examples only when the API is straightforward.

Use primary constructors wherever they make derived classes clearer:

```csharp
public sealed class AddProductFeature(IProductRepository repository)
    : GenericAddFeature<AddProductRequest, IProductRepository, Product, ProductDto>(repository)
{
    protected override Task<Product> ConvertToEntity(AddProductRequest request, CancellationToken cancellationToken)
        => Task.FromResult(new Product { Id = Guid.NewGuid(), Name = request.Name, Price = request.Price });

    protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
        => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
}
```

Framework and pattern classes must have class-level examples, especially:

- `FeatureDefinitionBase`
- `AddFeatureBase`
- `UpdateFeatureBase`
- `DeleteFeatureBase`
- `ListFeatureBase`
- `FindByIdFeatureBase`
- `ExistsByIdFeatureBase`
- all `Generic*Feature` classes
- repository base classes
- `WebModule`
- dependency injection attributes
- option/configuration classes
- test-builder base classes

Simple DTOs, records, enums, and constants do not need class-level examples unless the example clarifies real usage.

## API-Specific Guidance

For feature base methods:

- `CheckDuplicateAsync`: describe it as the validation hook before create/update mutation.
- `ConvertToEntity`: describe request-to-entity mapping before persistence.
- `ConvertToDto`: describe entity-to-DTO mapping before returning to callers.
- `PatchEntityAsync`: describe updating the loaded entity before saving.
- `CanBeDeletedAsync`: describe the deletion guard.
- `ConvertToPagedResultAsync` and `ConvertResult`: describe result-shape conversion.
- `AddAsync`, `UpdateAsync`, `DeleteAsync`, `ListAsync`, `FindByIdAsync`: describe the actual lifecycle, not just the method name.

For repositories:

- Explain whether the repository is in-memory, JSON, XML, EF, or EF Core backed.
- Explain when data is loaded, saved, queried, or paged.
- Include persistence caveats when visible in source.

For web modules:

- Explain what `ConfigureServices` registers before build.
- Explain what `ApplyConfigurationToAsync` applies after build.
- Include module caveats such as `ResponseCachingModule.ApplyConfigurationToAsync` throwing `NotImplementedException`.

## Backlinks

Always preserve both backlink types:

- Documentation hierarchy: member -> type -> namespace -> package -> package index -> home.
- Source links to GitLab `master`, with line anchors when available.

Use relative Markdown links inside generated docs. Use absolute GitLab links only for source references.

## Validation

After documentation changes:

- Run the generator dry-run to confirm included and excluded projects.
- Regenerate docs.
- Run `python -m mkdocs build --strict` from `docs`.
- Spot-check at least one package page, one type page, one method page, and one property/value page.
- Confirm generated docs do not link to tests, samples, templates, console/test hosts, `bin`, `obj`, generated files, or migrations.
