FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY src/deep.wefood.api.Domain/deep.wefood.api.Domain.csproj ./src/deep.wefood.api.Domain/
COPY src/deep.wefood.api.Presentation/deep.wefood.api.Presentation.csproj ./src/deep.wefood.api.Presentation/
COPY src/deep.wefood.api.Infrastructure/deep.wefood.api.Infrastructure.csproj ./src/deep.wefood.api.Infrastructure/

COPY deep.wefood.api.sln ./

RUN dotnet restore deep.wefood.api.sln

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 5000
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "deep.wefood.api.Presentation.dll"]
