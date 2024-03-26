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

# Page state management
When a user navigates to a different page, the state of the current page is lost. This is because the page is reloaded and the state is reset. To maintain the state of the page, we will be storing the following information in products.service.ts:
* List of categories
* Search term. If the search term is used, the list of categories are ignored from the search
* When the data selection is made by category, the search term is ignored and deleted from teh state.
* The state consists on an object with the following properties:
	* categories: string[]
	* searchTerm: string
	* pageIndex: number //the current page number -1 selected
	* pageSize: number //the number of items to display on the page
	* totalItems: number //the total number of items in the database for the current serch term or list of categories
	* pageActivated: boolean //a flag to indicate if the page has been activated
	

# Workflow for pagination and filtering
1. The product listing page come into view. 
	* Check the page state if the page was activated
 		* send a request to the server to retrieve the items to display on the page.
    * When items are retrieved, update the page state with the total number of items
		* Recalculate the number of pages to display
		* update the pagination controls
		* update the state of the page
	If the page was not activated:
		* Check what categories are already selected
			* Update page state with page index = 0 , page size = default page size
			* send a request to the server to retrieve the items to display on the page.
    		* When items are retrieved, update the page state with the total number of items
			* Recalculate the number of pages to display
			* update the pagination controls
			* update the state of the page

2. The client selects/Deselects a category. 
* A new set of categories is created and the page state is updated with the new set of categories
* The UpdatePage is called

3. User clicks on the pagination controls
	* The new page index is updated in the page state
* *The updatepage is called
	* 
4. The search bar is clicked
1	. The page state is updated
1. The updatepage is called


1. 1. The server retrieves the page number and page size from the query parameters and uses them to calculate the number of items to skip and the number of items to take.
1. The server retrieves the items from the database using the skip and take values.
1. The client receives the items and the total number of items from the server and uses them to display the items and create the pagination controls.


# Topics
Topics are pages or page fragments left for the user of the application to customize the content

The topis are stored in the database and are retrieved by the client when the page is loaded. The topics are displayed int the order or displayOrder field, if there are more on the same page
The topics can be refered by the topicId of the topic name, or by the topic page
The topic page may not be unique, but the topicId is unique as well the topic name
If the topic is retrieved by the pagename, the api will return a collection of topics. The client will have the choice to select the topic
The 