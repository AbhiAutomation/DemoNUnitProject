pipeline {
    agent any

    environment {
        IMAGE_NAME = "nunit-automation"
        CONTAINER_NAME = "nunit-test-container"
    }

    stages {

        stage('Clone Code') {
            steps {
                checkout([
                    $class: 'GitSCM',
                    branches: [[name: '*/main']],
                    userRemoteConfigs: [[
                        url: 'https://github.com/AbhiAutomation/DemoNUnitProject.git'
                    ]]
                ])
            }
        }

        stage('Verify Files') {
            steps {
                sh 'pwd'
                sh 'ls -la'
            }
        }

        stage('Build Docker Image') {
            steps {
                sh 'docker build -t $IMAGE_NAME .'
            }
        }

        stage('Run NUnit Tests') {
            steps {
                sh '''
                    mkdir -p allure-results
                    docker run --rm \
                    -v $(pwd)/allure-results:/app/allure-results \
                    $IMAGE_NAME
                '''
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

    post {
        always {
            archiveArtifacts artifacts: 'allure-results/**', fingerprint: true
            cleanWs()
        }

        success {
            echo 'Pipeline executed successfully!'
        }

        failure {
            echo 'Pipeline failed. Check logs.'
        }
    }
}