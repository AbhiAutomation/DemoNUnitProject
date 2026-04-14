FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

COPY . .

# Install dependencies
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

# Install latest matching ChromeDriver (NEW METHOD)
RUN CHROME_VERSION=$(google-chrome --version | awk '{print $3}') && \
    MAJOR_VERSION=$(echo $CHROME_VERSION | cut -d '.' -f 1) && \
    DRIVER_VERSION=$(curl -s https://googlechromelabs.github.io/chrome-for-testing/LATEST_RELEASE_$MAJOR_VERSION) && \
    wget -O /tmp/chromedriver.zip https://edgedl.me.gvt1.com/edgedl/chrome/chrome-for-testing/$DRIVER_VERSION/linux64/chromedriver-linux64.zip && \
    unzip /tmp/chromedriver.zip -d /tmp/ && \
    mv /tmp/chromedriver-linux64/chromedriver /usr/local/bin/chromedriver && \
    chmod +x /usr/local/bin/chromedriver && \
    rm -rf /tmp/chromedriver*

# Install Allure
RUN wget https://github.com/allure-framework/allure2/releases/download/2.29.0/allure-2.29.0.zip && \
    unzip allure-2.29.0.zip -d /opt/ && \
    ln -s /opt/allure-2.29.0/bin/allure /usr/bin/allure && \
    rm allure-2.29.0.zip

RUN chmod +x /app/run-tests.sh

ENTRYPOINT ["sh", "/app/run-tests.sh"]