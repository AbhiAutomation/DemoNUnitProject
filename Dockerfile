FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

# Copy project files
COPY . .

# Restore dependencies
RUN dotnet restore

# Build project
RUN dotnet build --no-restore

# Run API tests only
CMD ["dotnet", "test", "--filter", "Category=API"]