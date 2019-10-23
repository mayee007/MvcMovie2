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
		SECONDARY_VAR = "something-${DEPLOY_ENV}-end"
    }
    
    stages {
        stage('cleanup') {
            steps {
				powershell '''Write-Output "Branch name = $($env:BRANCH_NAME)"
                	      Write-Output  "Removing all files"
                              Remove-Item -Path "$($env:WORKSPACE)\\dir1" -Recurse ''' 
                bat 'dir "%WORKSPACE%"'
				echo "DEPLOY_ENV = %DEPLOY_ENV%"
				echo "SECONDARY_VAR = %SECONDARY_VAR%"
            } 
        } // end of cleanup
		stage('for dev') {
			when {
				branch 'dev' 
			}
			steps {
				echo "executing steps for dev"
				powershell ''' New-Item -ItemType File -Path dev.txt '''
			}
		}
		
		stage('for master') {
			when {
				branch 'master' 
			}
			steps {
				echo "executing steps for master"
				powershell ''' New-Item -ItemType File -Path master.txt '''
			}
		}
        stage('Setup') {
            steps {
                powershell ''' Write-output "Creating dir and files" ''' 
                powershell ''' New-Item -ItemType Directory -Force -Path $($env:SUBDIR_WIN) 
                               New-Item -ItemType File -Path "$($env:SUBDIR_WIN)\\ps.txt" '''
            } 
        } // end of setup 
        stage('display') {
            steps {
                bat 'dir "%SUBDIR_WIN%"'
                echo "${WORKSPACE}"
            }
        }
		stage('Deploy') {
			steps { 
				echo "deploying to ${DEPLOY_ENV}"
			}
		}
		
    }
}