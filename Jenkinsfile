pipeline {
    agent any 
    environment {
        nexus_ver = "something-${env.BUILD_NUMBER}"
        SUBDIR = "dir1/subdir/subsubdir"
        SUBDIR_WIN = "${env.WORKSPACE}\\dir1\\subdir\\subsubdir"
        DOTNET = "C:\\Program Files\\dotnet\\dotnet.exe"
    }
    
    stages {
        stage('cleanup') {
            steps {
		powershell '''Write-Output "Branch name = $($env:BRANCH_NAME)"
                powershell '''Write-Output  "Removing all files"
                              Remove-Item -Path "$($env:WORKSPACE)\\dir1" -Recurse ''' 
                bat 'dir "%WORKSPACE%"'
            } 
        } // end of cleanup 
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
                bat 'dir "%WORKSPACE%"'
            }
        }
    }
}