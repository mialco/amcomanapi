# Working with migrations

## Remove migrations:
		
		Remove-Migration -Force 
		# Removes a migration even after the database has been updated
		
## Add migration

		`Add-Migration InitialDatabaseMigration`

## Update the database

		`update-database

# Setup environment variables

		Start powershell as an administrator and run the following commands to set the environment variables:

		$env:ASPNETCORE_ENVIRONMENT = "Development"
		$env:ASPNETCORE_ENVIRONMENT = "Production"
		$env:JwtKey = "your-secret-key"
		To permanently set an environment variable, use the following command:

		[System.Environment]::SetEnvironmentVariable("JwtKey", "your-secret-key", "Machine")
		[System.Environment]::SetEnvironmentVariable("Jwt:Issuer", "your-secret-key", "Machine")

# User registration:
For user registrattion, if the role is not provided, (user self registration), then the user will be assigne automatincallu to the "User" role. If the role is provided, then the user will be assigned to the role provided.
