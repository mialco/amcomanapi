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


# Workflow for pagination and filtering
1. The client sends a request to the server with the page number and page size as query parameters.
2. The server retrieves the page number and page size from the query parameters and uses them to calculate the number of items to skip and the number of items to take.
1. The server retrieves the items from the database using the skip and take values.
1. The client receives the items and the total number of items from the server and uses them to display the items and create the pagination controls.