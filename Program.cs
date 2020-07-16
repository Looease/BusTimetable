using System;
using RestSharp;
using System.Linq;

namespace Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            //Below we are calling the TransportApi Client Class from that file
            var transportApiClient = new TransportApiClient();

            //Below we are calling the postcode API Client
            var postcodeAPiClient = new PostcodeApiClient();

            //The user will input their stopcode to find out what buses are near them
            //We will create a method for this below
            // var postCodeInput = GetPostCodeFromUser();

            var postCodeInput = "Hp3 8jf";

            var postcode = postcodeAPiClient.GetCoordinatesforPostcode(postCodeInput);

            //We are making a variable that summarises the above and the Transport API Client Class
            //Below we are calling the library we made with RestSharp 
            // This works because in the Transport API CLASS file we import the BusDepartureResponse on line 35 and then we call theTransport API Class above
            //We made our stopcode prop above and the method below and now we can call what the user enters from line 28
            var departures = transportApiClient.GetBusDeparturesForStop("490008660N");
            
            //FINAL STEP BELOW - We print
            PrintNextBuses(departures);

        }


            //Our Method for printing
            //line 34 links up with the Departures class on BusDepartureResponse which contains the Departure info class (Line/Direction etc)
            //By starting at [0] we include all the data we have asked for in the DepartureInfo class
            //Line  37 we only want the first five bses so use TAKE(number) instead of ALL
            private static void PrintNextBuses(BusDepartureResponse departures)
            {
                Console.WriteLine("\n\nNext buses at {departures.Name}");
                foreach (var departure in departures.Departures.All.Take(5))
                {
                    Console.WriteLine("Line: {departures.Line},To: {departure.Direction}, Leaving at:{departure.ExpectedDepartureTime}");
                }
            }

            //Method below to GET the stop code from the user 
            private static string GetPostCodeFromUser(){
                Console.WriteLine("Please enter your postcode:");
                return Console.ReadLine();
                //Methods need to return something

            }
    }
}
