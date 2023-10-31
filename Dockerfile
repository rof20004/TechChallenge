FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TechChallenge/TechChallenge.csproj", "src/TechChallenge/"]
COPY ["src/TechChallenge.Application/TechChallenge.Application.csproj", "src/TechChallenge.Application/"]
COPY ["src/TechChallenge.Domain/TechChallenge.Domain.csproj", "src/TechChallenge.Domain/"]
COPY ["src/TechChallenger.Infra/TechChallenge.Infra.csproj", "src/TechChallenger.Infra/"]
RUN dotnet restore "src/TechChallenge/TechChallenge.csproj"
COPY . .
WORKDIR "/src/src/TechChallenge"
RUN dotnet build "TechChallenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet tool install -g dotnet-ef
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet publish "TechChallenge.csproj" -c Release -o /app/publish /p:UseAppHost=false
RUN dotnet ef migrations bundle

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=publish /src/src/TechChallenge/efbundle .
RUN chmod +x efbundle
ENTRYPOINT ["dotnet", "TechChallenge.dll"]