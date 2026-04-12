FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

COPY . .

# Install required Linux packages
RUN apt-get update && apt-get install -y \
    wget \
    curl \
    unzip \
    gnupg

# Download Chrome package
RUN wget https://dl.google.com/linux/direct/google-chrome-stable_current_amd64.deb

# Install Chrome
RUN apt-get install -y ./google-chrome-stable_current_amd64.deb

# Restore and build project
RUN dotnet restore
RUN dotnet build

CMD ["dotnet", "test"]