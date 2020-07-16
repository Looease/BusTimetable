using System;
using RestSharp;

namespace Bus
{
    public class PostcodeApiClient
    {
        private RestClient client;

        public PostcodeApiClient()
        {
            client = new RestClient("http://api.postcodes.io/");

        }

        public Coordinates GetCoordinatesforPostcode(string postcode)
        {
            var request = new RestRequest("postcodes/{postcode}").AddUrlSegment("postcode", postcode);

            var response = client.Get<PostcodeResponse>(request);

            return response.Data.Result;




        }






    }




}
