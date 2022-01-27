#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Yzk18Main.MVC/Yzk18Main.MVC.csproj", "Yzk18Main.MVC/"]
RUN dotnet restore "Yzk18Main.MVC/Yzk18Main.MVC.csproj"
COPY . .
WORKDIR "/src/Yzk18Main.MVC"
RUN dotnet build "Yzk18Main.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Yzk18Main.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Yzk18Main.MVC.dll"]