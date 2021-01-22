# .NET 5 Domain Driven Design Solution
DDD (Domain Driven Design) solution in .NET 5 with simple WebAPI example and separated projects.
The goal is to show how to build a solution in DDD architecture, the codes are just examples of use.

> This DDD project is totally directed to the domain. The main difference of this solution is to protect the concrete codes (Application Services, Infrastructure) and to force the presentation layers (or UnitTest projects) to use only the interfaces and entities.

## :small_blue_diamond: References between projects

Note that the Domain layer has no reference to any project.

![projects references](https://raw.githubusercontent.com/hernaski/Domain-Driven-Design-Solution/master/readme/diagram-references.png)

The idea is to isolate the Services and Infrastructure projects. In this way, the presentation layers only know the domain (which contains only interfaces, isolating the concrete codes). The same happens if you insert a UnitTest project, you only need the Domain and Ioc project references.

To protect the projects with the concrete codes (Application Services, Infrastructure), we changed the *.csproj* of the IOC project (it makes the dependency injection). Basically, in the IOC project, it is necessary to insert `<PrivateAssets>All</PrivateAssets>` in the references of the other projects.

```xml
<ItemGroup>
	<ProjectReference Include="..\MySolution.Domain\MySolution.Domain.csproj">
		<PrivateAssets>All</PrivateAssets>
	</ProjectReference>
	<ProjectReference Include="..\MySolution.Infrastructure\MySolution.Infrastructure.csproj">
		<PrivateAssets>All</PrivateAssets>
	</ProjectReference>
	<ProjectReference Include="..\MySolution.Services\MySolution.Services.csproj">
		<PrivateAssets>All</PrivateAssets>
	</ProjectReference>
</ItemGroup>
```

The above change blocks the references to the presentation layer, so the presentation layer only needs the Domain and Ioc references.

The project configures the dependencies and then uses the interfaces (which are in the domain) of the Services and Infrastructure projects without needing to know how it is developed ("concrete codes").

Configuration in `Startup.cs` for dependency injection through the extension of `IServiceCollection` in the Ioc project:
```csharp
services.ConfigureDependencyInjectionMySolution();
```

Within this method you configure all `Services` and `Infrastructure` dependencies:

```csharp
// Services
services.AddScoped<ICategoryServices, CategoryServices>();
services.AddScoped<IProductServices, ProductServices>();

// Repositories
services.AddScoped<ICategoryRepository, CategoryRepository>();
services.AddScoped<IProductRepository, ProductRepository>();
```
## :small_blue_diamond: Change the solution your way

You can replace the Web.Api with Web Application or other projects. The important thing is the Services, Infrastructure and Domain layers are independent to receive another presentation layer.

![new projects](https://raw.githubusercontent.com/hernaski/Domain-Driven-Design-Solution/master/readme/diagram-new-projects.png)

## :small_blue_diamond: Solution operation

This diagram provides an overview of how this solution works at run time `run time diagram`:

![solution operation](https://raw.githubusercontent.com/hernaski/Domain-Driven-Design-Solution/master/readme/diagram-operation.png)

## :small_blue_diamond: Solution open in the browser

![webapi](https://raw.githubusercontent.com/hernaski/Domain-Driven-Design-Solution/master/readme/swagger.png)

## :small_blue_diamond: This solution architecture is suitable for
- [x] Monoliths or Microservices (one solution for each service);
- [x] gRPC services (replace the *.Services* project);
- [x] JWT Authentication (configure *Bearer* or other, policies, etc.);
- [x] TDD or Unit Tests (add UnitTest project and use only *.Domain* and *.Ioc* projects);
- [x] SOLID principles;
- [x] Design patterns (CQRS, etc.);
- [x] Migrations (configure in the infrastructure layer);
- [x] Cache or REDIS (configure Startup and create your component/class);
- [x] Cloud or cluster environment (be careful with session, cache, antiforgery, file system, etc.).
- [x] Angular/React/Vue (replace the *.Web.Api* project or create another to access the api);
- [x] MVC Web Applications (replace the *.Web.Api*). In MVC Web projects you don't need the *Models* folder because your models (entities) are in the Domain project. Use DTO's when necessary, e.g.: ProductResponse.

## :small_blue_diamond: Tips
- [x] Use more Native .NET and less third-party packages (e.g.: forget NewtonSoft and use System.Text.Json);
- [x] Don't put everything on Startup. Use middlewares or extensions methods;
- [x] Avoid inserting business rules in the infrastructure layer;
- [x] Avoid using EFCore outside the infrastructure layer;
- [x] Always use interfaces (Domain), so you can create a UnitTest project and test it more easily;
- [x] Avoid *Data Annotations* in your entities, use Fluent API. Use *Annotations* in ViewModels, if necessary;
- [x] Concentrate the nuget packages on the Domain project, by default the references are shared by other projects and makes it easier to update new versions. This is valid for packages used in the *Application Services* and *Infrastructure* layers. Packages used for presentation only shouldn't be in the domain project;
- [x] Always develop thinking the presentation layer is independent of the other layers. Imagine that you change the presentation layer from React to Angular, your domain, services and infrastructure layers shouldn't be changed due to this.

## :small_blue_diamond: Tools and frameworks used:
- Visual Studio 2019 (16.8.4)
- .NET 5 and Entity Framework Core 5
- Swagger
- Sample mdf database

Enjoy :+1: :smiley:
