FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

COPY . .

RUN apt-get update && apt-get install -y default-jre awscli wget unzip

RUN wget https://github.com/allure-framework/allure2/releases/download/2.29.0/allure-2.29.0.zip \
 && unzip allure-2.29.0.zip -d /opt/ \
 && ln -s /opt/allure-2.29.0/bin/allure /usr/bin/allure

RUN chmod +x run-tests.sh

ENTRYPOINT ["sh", "/app/run-tests.sh"]