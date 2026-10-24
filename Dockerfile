# Build da versão .NET 8 (pasta src/). O projeto Web Forms original continua na raiz só como histórico.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Restaura primeiro só os .csproj para aproveitar o cache de camadas do Docker
COPY src/ChateauDuPet.DTO/ChateauDuPet.DTO.csproj ChateauDuPet.DTO/
COPY src/ChateauDuPet.DAL/ChateauDuPet.DAL.csproj ChateauDuPet.DAL/
COPY src/ChateauDuPet.BLL/ChateauDuPet.BLL.csproj ChateauDuPet.BLL/
COPY src/ChateauDuPet.Web/ChateauDuPet.Web.csproj ChateauDuPet.Web/
RUN dotnet restore ChateauDuPet.Web/ChateauDuPet.Web.csproj

COPY src/ChateauDuPet.DTO/ ChateauDuPet.DTO/
COPY src/ChateauDuPet.DAL/ ChateauDuPet.DAL/
COPY src/ChateauDuPet.BLL/ ChateauDuPet.BLL/
COPY src/ChateauDuPet.Web/ ChateauDuPet.Web/
RUN dotnet publish ChateauDuPet.Web/ChateauDuPet.Web.csproj -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_ENVIRONMENT=Production \
    DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false \
    TZ=America/Sao_Paulo
USER app
EXPOSE 8080
ENTRYPOINT ["dotnet", "ChateauDuPet.Web.dll"]
