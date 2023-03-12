Feature: ValidateFactsEndpointwithUser

A short summary of the feature

@elab
Scenario Outline: Verify the facts endpoint with users and response data
	Given I have the endpoint "https://cat-fact.herokuapp.com"
	When I Get the facts
	Then I should get reponse code as OK
	And I validate the response of the <_id> with user <user> text <text> with <firstname> and <lastname> match <type>
Examples: 
| _id                      | user                     | text                                                                                                                                                                                     | firstname | lastname | type |
| 58e008800aac31001185ed07 | 58e007480aac31001185ecef | Wikipedia has a recording of a cat meowing, because why not?                                                                                                                             | Kasimir   | Schulz   | cat  |
| 58e008630aac31001185ed01 | 58e007480aac31001185ecef | When cats grimace, they are usually "taste-scenting." They have an extra organ that, with some breathing control, allows the cats to taste-sense the air.                                | Kasimir   | Schulz   | cat  |
| 58e00a090aac31001185ed16 | 58e007480aac31001185ecef | Cats make more than 100 different sounds whereas dogs make around 10.                                                                                                                    | Kasimir   | Schulz   | cat  |
| 58e009a90aac31001185ed23 | 58e007480aac31001185ecef | Cats can distinguish different flavors in water.                                                                                                                                         | Kasimir   | Schulz   | cat  |
| 58e009390aac31001185ed10 | 58e007480aac31001185ecef | Most cats are lactose intolerant, and milk can cause painful stomach cramps and diarrhea.  It's best to forego the milk and just give your cat the standard: clean, cool drinking water. | Kasimir   | Schulz   | cat  |
| 58e008780aac31001185ed05 | 58e007480aac31001185ecef | Owning a cat can reduce the risk of stroke and heart attack by a third.                                                                                                                  | Kasimir   | Schulz   | cat  |






