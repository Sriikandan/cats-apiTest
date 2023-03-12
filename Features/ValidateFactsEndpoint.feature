Feature: ValidateFactsEndpoint

A short summary of the feature

@elab
Scenario: Verify the facts endpoint is returns 200 with Response
	Given I have the endpoint "https://cat-fact.herokuapp.com"
	When I Get the facts
	Then I should get reponse code as OK
	And I validate the response having all the users as below:
	| users                    |
	| 58e007480aac31001185ecef |
	| 58e007480aac31001185ecef |
	| 58e007480aac31001185ecef |
	| 58e007480aac31001185ecef |
	| 58e007480aac31001185ecef |
	| 58e007480aac31001185ecef |





