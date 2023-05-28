Feature: RequestResponse

A short summary of the feature

@GET
Scenario: GET request testing
	Given the user sends a get request with url as 'https://reqres.in/api/users?page=2'
	Then I verify the response code is '200'

@POST
Scenario: POST request testing
	Given the user sends a post request with url as 'https://reqres.in/api/users?page=2'
	Then I verify the response code is '200'
