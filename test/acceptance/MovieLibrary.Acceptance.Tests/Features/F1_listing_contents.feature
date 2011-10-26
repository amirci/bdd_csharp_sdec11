Feature: Feature: Browse Movies
	As a User
	I want to Browse Movies
	So I can see the contents of the library


Scenario: Have movies in the library
	Given I have contents in the library
	When  I list the contents
	Then  I should see all the movies listed in the page
