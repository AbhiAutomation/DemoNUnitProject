pipeline {
    agent any

    stages {

        stage('Build Docker Image') {
            steps {
                bat 'docker build -t nunit-automation .'
            }
        }

        stage('Run NUnit Tests') {
            steps {
                bat 'docker run --rm -v "%cd%\\allure-results:/app/allure-results" nunit-automation'
            }
        }

        stage('Publish Allure Report') {
            steps {
                allure([
                    includeProperties: false,
                    jdk: '',
                    results: [[path: 'allure-results']]
                ])
            }
        }
    }
}