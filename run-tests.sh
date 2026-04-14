#!/bin/sh

echo "Running NUnit Tests..."

dotnet test /app/DemoNUnitProject.csproj --logger "console;verbosity=detailed" || true

echo "Generating Allure Report..."

allure generate /app/allure-results --clean -o /app/allure-report

echo "Uploading Allure Report to S3..."

aws s3 cp /app/allure-report s3://nunit-allure-reports-abhishek-815114590433/allure-report --recursive

echo "Done uploading report." 