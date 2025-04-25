# 8. KamiSama.Chassis
The Chassis collection is a set of lightweight extensions on AspNetCore that helps you to write less code and gain more productivity.


## 8.1 KamiSama.Chassis.HttpExceptions
Set of exception classes inherited from HttpExceptionBase.
These classes provide some default information and also can be used along with KamiSama.Chassis.ProblemDetails.

## 8.2 KamiSama.Chassis.ProblemDetails

The library is based on Microsoft AspNetCore ProblemDetails 
and helps you to handle errors in a more standardized manner.

To Setup you should add the following code to your project:
```csharp
//in Program.cs or Startup.cs

builder.Services.AddProblemDetails();
builder.Services
	.AddControllers()
	.AddExceptionFilterForProblemDetails();
```
### 8.2.1 Customization
You can also customize the conversion of problem details:
```csharp
builder.Services.AddProblemDetails();
builder.Services
	.AddControllers()
	.AddExceptionFilterForProblemDetails(opt => opt.UseProblemDetailsProvider(sp => new CustomProvider()));
```

That's easy!

### 8.2.2 Localization
The KamiSama Chassis problem details library supports localization. In order to use, you can define your own Resources.resx 
and use it in alongside the problem details. You need to add localization separately.

```csharp
builder.Services.AddProblemDetails();
builder.Services
	.AddControllers()
    .AddExceptionFilterForProblemDetails(opt => opt.UseResourceLocalizer<CustomResources>());
builder.Services.AddLocalization(); // adding localization
```

## 8.3 KamiSama.Chassis.Commons
The Commons library provides some basic functionality for a most Asp.net core projects. The KamiSama.Chassis.Commons comes in two libraries:
- KamiSama.Chassis.Commons.Abstractions: provides abstraction for concepts. Use it for your bounded contexts' abstractions.
- KamiSama.Chassis.Commons: provides implementations for Features and Repositories.

### 8.3.1 Features
Features are like services with new name. The KamiSama.Chassis.Commons provides some common CRUD services, like:
- IAddFeature and GenericAddFeature: adds an entity based on AddRequest
- IUpdateFeature and GenericUpdateFeature: updates an entity based on UpdateRequest and id
- IDeleteFeature and GenericDeleteFeature: Deletes an entity by id
- IListFeature and GenericListFeature: list and pages entities and also provides search and ordering functionality.
- IFindByIdFeature and GenericFindByIdFeature: finds an entity by key(id)
- IFindByNameFeature and GenericFindByNameFeature: finds an entity by name

### 8.3.2 Repositories
Repository interfaces and implementation for most CRUD scenarios:
- IAddableRepository
- IUpdatableRepository
- IListingRepository
- IDeletableRepository
- ILookupByIdRepository
- ILookupByCodeRepository

The library also provides basic implementation named GenericRepository with CRUD functionality. You should implement IFindByIdRepository and IFindByNameRepository by yourself. See KamiSama.Templates projects.

## 8.3.3 Helper Class

Using generic features (like GenericAddFeature, GenericDeleteFeature, ...) is not developer friendly as they need to repeat generic arguments again and again.
In order to avoid this, there is FeatureDefinitionBase class to help:
```csharp
public interface IAddMyEntity : IAddFeature<AddMyEntityRequst, MyEntityDto>
public class MyEntityFeatures : FeatureDefinitionBase<MyEntity, MyEntityDto, AddMyEntityRequest, UpdateMyEntityRequest, IMyEntityRpository, MyEntitySearchModel, Guid>
{
}

//in implementation
[AutoInjectScoped<IAddMyEntity>]
internal class AddMyEntity : MyEntityFeatures.AddFeature, IAddMyEntity
{
}
```