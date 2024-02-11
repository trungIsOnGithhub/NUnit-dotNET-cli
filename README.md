### Unit Testing .NET with Nunit

> Development with Ubuntu 20.04 LTS, .NET 6 SDK

- From main solution workspace

```shell
    dotnet sln ./*.sln add ./*.Test/*.csproj
```

- From *.Test folder

```shell
    dotnet add reference ../*.App/*.csproj
```

- Run test from anywhere
```shell
    dotnet test
```