pipeline {
    agent any

    stages {

        stage('Build Docker Image') {
            steps {
                sh 'docker build -t nunit-automation .'
            }
        }

        stage('Run NUnit Tests') {
            steps {
                sh '''
                    mkdir -p allure-results
                    docker run --rm \
                    -v $(pwd)/allure-results:/app/allure-results \
                    nunit-automation
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
        }
    }
}