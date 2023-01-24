FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["src/ActiveDirectoryTest.Web.Host/ActiveDirectoryTest.Web.Host.csproj", "src/ActiveDirectoryTest.Web.Host/"]
COPY ["src/ActiveDirectoryTest.Web.Core/ActiveDirectoryTest.Web.Core.csproj", "src/ActiveDirectoryTest.Web.Core/"]
COPY ["src/ActiveDirectoryTest.Application/ActiveDirectoryTest.Application.csproj", "src/ActiveDirectoryTest.Application/"]
COPY ["src/ActiveDirectoryTest.Core/ActiveDirectoryTest.Core.csproj", "src/ActiveDirectoryTest.Core/"]
COPY ["src/ActiveDirectoryTest.EntityFrameworkCore/ActiveDirectoryTest.EntityFrameworkCore.csproj", "src/ActiveDirectoryTest.EntityFrameworkCore/"]
WORKDIR "/src/src/ActiveDirectoryTest.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/ActiveDirectoryTest.Web.Host", "src/ActiveDirectoryTest.Web.Host"]
COPY ["src/ActiveDirectoryTest.Web.Core", "src/ActiveDirectoryTest.Web.Core"]
COPY ["src/ActiveDirectoryTest.Application", "src/ActiveDirectoryTest.Application"]
COPY ["src/ActiveDirectoryTest.Core", "src/ActiveDirectoryTest.Core"]
COPY ["src/ActiveDirectoryTest.EntityFrameworkCore", "src/ActiveDirectoryTest.EntityFrameworkCore"]
WORKDIR "/src/src/ActiveDirectoryTest.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "ActiveDirectoryTest.Web.Host.dll"]
