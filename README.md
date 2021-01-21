# .NET 5 Domain Driven Design Solution
DDD (Domain Driven Design) solution in .NET 5 with simple WebAPI example and separated projects.
The goal is to show how to build a solution in DDD architecture, the codes are just examples of use.

This DDD project is totally directed to the domain, using only interfaces and entities.
The main difference of this solution is to protect the concrete codes (Application Services, Infrastructure) and to force the presentation layer projects to use only the interfaces and entities.

To protect the projects with the concrete codes, we changed the [.csproj] of the IOC project (it makes the dependency injection). Basically, in the IOC project, it is necessary to insert &lt;PrivateAssets&gt;All&lt;/PrivateAssets&gt; in the references of the other projects.

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

In this way, concrete codes cannot be accessed by any project (except IOC). Forcing the use of domain entities and interfaces with dependency injection.

# References between projects
![projects references](https://raw.githubusercontent.com/hernaski/Domain-Driven-Design-Solution/master/readme-diagram-references.png)

# Solution operation
![solution operation](https://raw.githubusercontent.com/hernaski/Domain-Driven-Design-Solution/master/readme-diagram-operation.png)

# Solution open in browser
![webapi](https://raw.githubusercontent.com/hernaski/Domain-Driven-Design-Solution/master/readme-swagger.png)

# This solution architecture is suitable for
- [x] Angular/React/Vue (replace the *.Web.Api* project or create another to access the api);
- [x] Microservices (one solution for each service);
- [x] gRPC services (replace the *.Services* project);
- [x] Include JWT Authentication (configure Bearer or other);
- [x] TDD or Unit Tests (add UnitTest project and use only *.Domain* and *.Ioc* projects);
- [x] SOLID principles;
- [x] Design patterns (CQRS, etc.);
- [x] Migrations (configure in the infrastructure layer);
- [x] Cache or REDIS (configure Startup and create your component/class);
- [x] Cloud or cluster environment (be careful with session, cache, antiforgery, file system, etc.).

# Tips
- [x] Use more Native .NET and less third-party packages (e.g.: forget NewtonSoft and use System.Text.Json);
- [x] Don't put everything on Startup. Use middlewares or extensions methods;
- [x] Avoid inserting business rules in the infrastructure layer;
- [x] Avoid using EFCore outside the infrastructure layer;
- [x] Always use interfaces (Domain), so you can create a UnitTest project and test it more easily;
- [x] Avoid *Data Annotations* in your entities, use Fluent API. Use *Annotations* in ViewModels, if necessary;
- [x] Imagine that you are going to delete the Presentation project and build a new Angular project. Always develop so that the other layers are independent of the presentation.

# Tools and frameworks used:
- Visual Studio 2019 (16.8.4)
- .NET 5 and Entity Framework Core 5
- Swagger
- Sample mdf database

Enjoy :+1:
