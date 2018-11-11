FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 36968
EXPOSE 44373

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY CM.Services/CM.Services.Wallet/CM.Services.Wallet.API/CM.Services.Wallet.API.csproj CM.Services/CM.Services.Wallet/CM.Services.Wallet.API/
COPY CM.Shared/CM.Shared.Web/CM.Shared.Web.csproj CM.Shared/CM.Shared.Web/
COPY CM.Services/CM.Services.Wallet/CM.Services.Wallet.Concrete/CM.Services.Wallet.Concrete.csproj CM.Services/CM.Services.Wallet/CM.Services.Wallet.Concrete/
COPY CM.Services/CM.Services.Wallet/CM.Services.Wallet.Infrastracture/CM.Services.Wallet.Infrastracture.csproj CM.Services/CM.Services.Wallet/CM.Services.Wallet.Infrastracture/
RUN dotnet restore CM.Services/CM.Services.Wallet/CM.Services.Wallet.API/CM.Services.Wallet.API.csproj
COPY . .
WORKDIR /src/CM.Services/CM.Services.Wallet/CM.Services.Wallet.API
RUN dotnet build CM.Services.Wallet.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CM.Services.Wallet.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CM.Services.Wallet.API.dll"]
