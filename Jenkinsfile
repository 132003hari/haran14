pipeline {
    agent any
    environment {
        DOCKER_IMAGE_VERSION = "1.1.${BUILD_ID}"
        DOCKER_IMAGE_NAME = "haribala132003/users"
    }
    options {
  buildDiscarder logRotator(artifactDaysToKeepStr: '', artifactNumToKeepStr: '', daysToKeepStr: '', numToKeepStr: '5')
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
                            sh "docker build -t ${DOCKER_IMAGE_NAME}:${DOCKER_IMAGE_VERSION} -f /var/jenkins_home/workspace/dotnet/Dockerfile ."
                        }
                    }
                }
                stage('Push Docker Image') {
                    steps {
                        script {
                            sh "docker login -u haribala132003 -p haran/hari"
                            sh "docker push ${DOCKER_IMAGE_NAME}:${DOCKER_IMAGE_VERSION}"
                        }
                    }
                }
         stage('Pull Docker Image') {
            steps {
                script {
                           sh "docker login -u haribala132003 -p haran/hari"
                            sh "docker pull ${DOCKER_IMAGE_NAME}:${DOCKER_IMAGE_VERSION}"
                    }
                }
            }
        stage('Cleanup Docker Images') {
            steps {
                script{
                sh 'docker system prune -a '
                }
            }
        }
       

    }
    post{
        success{
            emailext body: 'email sent from jenkins', subject: 'build suceed', to: 'haribala132003@gmail.com '
        }
        failure{
          emailext body: 'email sent from jenkins', subject: 'build failed', to: 'haribalakarpagam@gmail.com '
  
        }
        always{
            slackSend channel: 'build', message: 'project asp build ${DOCKER_IMAGE_NAME}'
            slackSend channel: 'build', message: 'Visit the url to check my build ${URL}'
        }
    }
}

