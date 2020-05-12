def getEnvFromBranch(branch) {
  if (branch == 'master') {
    return 'production'
  } else if (branch == 'test1') {
    return 'development' 
 } else { 
	return 'staging'
 }
 
}

pipeline {
    agent any 
    environment {
        nexus_ver = "something-${env.BUILD_NUMBER}"
        SUBDIR = "dir1/subdir/subsubdir"
        SUBDIR_WIN = "${env.WORKSPACE}\\dir1\\subdir\\subsubdir"
        DOTNET = "C:\\Program Files\\dotnet\\dotnet.exe"
		DEPLOY_ENV = getEnvFromBranch(env.BRANCH_NAME)
		SECONDARY_VAR = 'something-${DEPLOY_ENV}-end'
    }
    
    stages {
        stage('checkout') {
            steps {
					git 'https://github.com/mayee007/MvcMovie2.git'
				}
        } 
		 
        stage('Build') {
            steps {
                bat 'dotnet build'
            }
        }
		stage('Postman Testing') {
			steps { 
				bat "cd tests && newman run MVCMovie.postman_collection.json -e LocalHost.postman_environment.json -d postman_data.json -k"
			}
		}
		
    }
}