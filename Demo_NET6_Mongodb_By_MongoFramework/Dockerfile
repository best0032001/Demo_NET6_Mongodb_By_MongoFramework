FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY [".", "."]
RUN dotnet restore "Demo_NET6_Mongodb_By_MongoFramework.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "Demo_NET6_Mongodb_By_MongoFramework.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Demo_NET6_Mongodb_By_MongoFramework.csproj" -c Release -o /app

FROM base AS final


ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV ORIGIN=* 
ENV TZ=Asia/Bangkok

COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Demo_NET6_Mongodb_By_MongoFramework.dll"]

