using System;
using RestSharp;

namespace Bus
{
    public class TransportApiClient
    //this is the class that is going to make our API call and return our objects
    {
        //This is RestSharp 
        // we define the variable client on line 16 and now RestClient is calling it. 
        private RestClient client;

        //This is the class to call info from the API
        public TransportApiClient()
        {
            client = new RestClient("https://transportapi.com/");
            //^This varible is calling the transport API general website 
        }

        public BusDepartureResponse GetBusDeparturesForStop(string stopcode)
            //This class is getting the PATH USING QUEREY PARAMETERS(group,nextbuses, appID, app key) - POSTMAN breaks down the Query Parameters very clearly for us. 
        {   // It seems that QUERY PARAMETERS are unique to the URL (doesn't have to be app_id/app_key etc.)
            // The below URL returns our JSON
            // THE PATH starts at V3 after the general site. 

            //We are calling the stopcode on line 32. We need a variable so its not just fixed to one stopcode
            // When working with URLs variables can't have things like spaces because the browser won't read it so we can use RestSharp
            // RestSharp makes this LOADS EASIER as we can just add a Query Parameter of stopcode (line 30) then it will search the Json for something that resembles stopcode
            // For our example we know we want the stopcode because in the URL that is where it declares a different bus stop like this stop/490008660N/ - the numher at the end changes per stop
            // We need to use URL segment on line 32 as its not just a parameter its the DATA
            var request = new RestRequest("v3/uk/bus/stop/{stopcode}/live.json")
                .AddUrlSegment(name:"stopcode", stopcode)
                .AddQueryParameter("app_id", "3d4e7caf")
                .AddQueryParameter("app_key", "d6e85b063f40ecaa367a39324004c466")
                .AddQueryParameter("group", "no")
                .AddQueryParameter("nextbuses", "yes")
                .AddUrlSegment("stopcode", stopcode );

            //We then want to call our URL which we do below
            //Get is a magic COMPUTER WORD term that just does the work for us
            // OUr job is to make sure the data we want to get (BusDepartureResponse) matches the URL and REST Sharp does the rest.
            //Below we are calling the BusDepartureResponse.cs file 
            var response = client.Get<BusDepartureResponse>(request);
            return response.Data;

        }
    }
}


        // This is our original API that is broken down above ^
        // https://transportapi.com/v3/uk/bus/stop/490008660N/live.json?app_id=3d4e7caf&app_key=d6e85b063f40ecaa367a39324004c466&group=no&nextbuses=yes
