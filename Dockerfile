FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

# Copy project files
COPY . .

# Install required packages + Chrome dependencies
RUN apt-get update && apt-get install -y \
    default-jre \
    awscli \
    wget \
    unzip \
    curl \
    gnupg \
    xvfb \
    fonts-liberation \
    libnss3 \
    libatk-bridge2.0-0 \
    libxss1 \
    libasound2 \
    libgbm1 \
    libgtk-3-0 \
    --no-install-recommends

# Install Google Chrome
RUN wget -q -O - https://dl.google.com/linux/linux_signing_key.pub | gpg --dearmor -o /usr/share/keyrings/google-linux.gpg && \
    echo "deb [arch=amd64 signed-by=/usr/share/keyrings/google-linux.gpg] http://dl.google.com/linux/chrome/deb/ stable main" \
    > /etc/apt/sources.list.d/google-chrome.list && \
    apt-get update && \
    apt-get install -y google-chrome-stable

# Install matching ChromeDriver automatically
RUN CHROME_VERSION=$(google-chrome --version | awk '{print $3}' | cut -d '.' -f 1) && \
    DRIVER_VERSION=$(curl -sS https://chromedriver.storage.googleapis.com/LATEST_RELEASE_$CHROME_VERSION) && \
    wget -O /tmp/chromedriver.zip https://chromedriver.storage.googleapis.com/$DRIVER_VERSION/chromedriver_linux64.zip && \
    unzip /tmp/chromedriver.zip -d /usr/local/bin/ && \
    chmod +x /usr/local/bin/chromedriver && \
    rm /tmp/chromedriver.zip

# Install Allure
RUN wget https://github.com/allure-framework/allure2/releases/download/2.29.0/allure-2.29.0.zip && \
    unzip allure-2.29.0.zip -d /opt/ && \
    ln -s /opt/allure-2.29.0/bin/allure /usr/bin/allure && \
    rm allure-2.29.0.zip

# Fix shell script permissions
RUN chmod +x /app/run-tests.sh

ENTRYPOINT ["sh", "/app/run-tests.sh"]