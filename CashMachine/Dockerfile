#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CashMachine/CashMachine.csproj", "src/CashMachine/"]
COPY ["src/Application/CashMachine.Application/CashMachine.Application.csproj", "src/Application/CashMachine.Application/"]
COPY ["src/Application/CashMachine.Application.Abstractions/CashMachine.Application.Abstractions.csproj", "src/Application/CashMachine.Application.Abstractions/"]
COPY ["src/Application/CashMachine.Application.Models/CashMachine.Application.Models.csproj", "src/Application/CashMachine.Application.Models/"]
COPY ["src/Application/CashMachine.Application.Contracts/CashMachine.Application.Contracts.csproj", "src/Application/CashMachine.Application.Contracts/"]
COPY ["src/Infrastructure/CashMachine.Infrastructure.DataAccess/CashMachine.Infrastructure.DataAccess.csproj", "src/Infrastructure/CashMachine.Infrastructure.DataAccess/"]
COPY ["src/Presentation/CashMachine.Presentation.Console/CashMachine.Presentation.Console.csproj", "src/Presentation/CashMachine.Presentation.Console/"]
RUN dotnet restore "./src/CashMachine/./CashMachine.csproj"
COPY . .
WORKDIR "/src/src/CashMachine"
RUN dotnet build "./CashMachine.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CashMachine.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CashMachine.dll"]