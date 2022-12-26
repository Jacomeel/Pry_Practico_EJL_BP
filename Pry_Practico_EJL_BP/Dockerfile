#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Pry_Practico_EJL_BP/Pry_Practico_EJL_BP.csproj", "Pry_Practico_EJL_BP/"]
RUN dotnet restore "Pry_Practico_EJL_BP/Pry_Practico_EJL_BP.csproj"
COPY . .
WORKDIR "/src/Pry_Practico_EJL_BP"
RUN dotnet build "Pry_Practico_EJL_BP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pry_Practico_EJL_BP.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pry_Practico_EJL_BP.dll"]