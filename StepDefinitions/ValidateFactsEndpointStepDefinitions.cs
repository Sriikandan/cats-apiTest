using APIValidation.APIValidation;

namespace APIValidation.StepDefinitions
{
    [Binding]
    public class ValidateFactsEndpointStepDefinitions
    {
        public CatsEndpoint catsAPI = new CatsEndpoint();

        [Given(@"I have the below endpoint:")]
        public void GivenIHaveTheBelowEndpoint(TableRow row)
        {
            var endpoint = row["endpoint"];
            catsAPI.stroreEndpoint(endpoint);
        }

        [Given(@"I have the endpoint ""([^""]*)""")]
        public void GivenIHaveTheEndpoint(string url)
        {

            catsAPI.stroreEndpoint(url);
        }


        [When(@"I Get the facts")]
        public void WhenIGetTheFacts()
        {
            catsAPI.requestAPIAsync();
        }

        [Then(@"I should get reponse code as (.*)")]
        public void ThenIShouldGetReponseCodeAsOK(string responseCode)
        {
            catsAPI.validateResponseCode(responseCode);
        }

        [Then(@"I validate the response having all the users as below:")]
        public void ThenIValidateTheResponseHavingAllTheUsersAsBelow(Table table)
        {

            foreach (var row in table.Rows)
            {
                string user = row[0];
                catsAPI.confirmUserResponse(user);
            }
        }


        [Then(@"I validate the response of the (.*) with user (.*) text (.*) with (.*) and (.*) match (.*)")]
        public void ThenIValidateTheResponseOfTheuser(string id, string user, string text, string firstname, string lastname, string type)
        {
            catsAPI.requestAPIfor(id);
            catsAPI.confirmUserReponseData(id, "user", user);
            catsAPI.confirmUserReponseData(id, "text", text);
            catsAPI.confirmUserReponseData(id, "firstname", firstname);
            catsAPI.confirmUserReponseData(id, "lastname", lastname);
            catsAPI.confirmUserReponseData(id, "type", type);



        }



    }



}
