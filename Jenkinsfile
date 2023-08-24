pipeline {
    agent any
    environment {
        DOCKER_IMAGE_VERSION = "1.1.${BUILD_ID}"
        DOCKER_IMAGE_NAME = "haribalala/user"
    }

    stages {
        stage('Build') {
            tools {
                dotnetsdk 'dotnet-sdk-7.0'
            }
            steps {
                echo 'Building..'
                sh '''
                dotnet build
                '''
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
                sh '''
                echo "Testing Successfull.."
                '''
            }
        }
        stage('Deliver') {
            steps {
                echo 'Deliver....'
                sh '''
                echo "doing delivery stuff.."
                '''
            }
        }
        stage('Build Docker Image') {
                    steps {
                        script {
                            sh "docker build -t ${DOCKER_IMAGE_NAME}:${DOCKER_IMAGE_VERSION} -f /var/jenkins_home/workspace/asp.net/Dockerfile ."
                        }
                    }
                }
                stage('Push Docker Image') {
                    steps {
                        script {
                            sh "docker login -u eswaramoorthi -p esk2381313"
                            sh "docker push ${DOCKER_IMAGE_NAME}:${DOCKER_IMAGE_VERSION}"
                        }
                    }
                }

    }

}
