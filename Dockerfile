FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 7152

ENV ASPNETCORE_URLS=http://+:7152

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["DIUN_dotnet_mvc_statuspage.csproj", "./"]
RUN dotnet restore "DIUN_dotnet_mvc_statuspage.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DIUN_dotnet_mvc_statuspage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DIUN_dotnet_mvc_statuspage.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DIUN_dotnet_mvc_statuspage.dll"]
