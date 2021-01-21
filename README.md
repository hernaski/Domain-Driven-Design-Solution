# Domain-Driven-Design-Solution
DDD (Domain Driven Design) solution in .NET 5 with simple WebAPI example and separated projects.
The goal is to show how to build a solution in DDD architecture, the codes are just examples of use.

This solution is totally directed to the domain, using only interfaces and entities.
The main difference of this solution is to protect the concrete codes (Application Services, Infrastructure) and to force the presentation layer projects to use only the interfaces and entities.

To protect the projects with the concrete codes, we changed the [.csproj] of the IOC project (serves to inject the dependencies).

Basically, it is necessary to insert <PrivateAssets>All</PrivateAssets> in the references of the other projects.

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
