FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app
COPY . /app
RUN dotnet restore
ENTRYPOINT ["dotnet", "run"]