FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY ./TechnicalChallenge.API.sln ./
COPY ./TechnicalChallenge.API/TechnicalChallenge.API.csproj  ./TechnicalChallenge.API/TechnicalChallenge.API.csproj
COPY ./TechnicalChallenge.BLL/TechnicalChallenge.BLL.csproj  ./TechnicalChallenge.BLL/TechnicalChallenge.BLL.csproj
COPY ./TechnicalChallenge.Common/TechnicalChallenge.Common.csproj  ./TechnicalChallenge.Common/TechnicalChallenge.Common.csproj
COPY ./TechnicalChallenge.DAL/TechnicalChallenge.DAL.csproj  ./TechnicalChallenge.DAL/TechnicalChallenge.DAL.csproj
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "TechnicalChallenge.API.dll"]