FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

# Copy csproj first for cache optimization
COPY *.csproj ./

# Restore dependencies first
RUN dotnet restore

# Install Linux dependencies
RUN apt-get update && apt-get install -y \
    wget \
    curl \
    unzip \
    gnupg \
 && rm -rf /var/lib/apt/lists/*

# Add Google Chrome repository
RUN wget -q -O - https://dl.google.com/linux/linux_signing_key.pub | apt-key add - && \
    sh -c 'echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" > /etc/apt/sources.list.d/google.list'

# Install Chrome
RUN apt-get update && apt-get install -y google-chrome-stable \
 && rm -rf /var/lib/apt/lists/*

# Copy remaining source code
COPY . .

# Build project
RUN dotnet build --no-restore

CMD ["dotnet", "test", "--no-build"]