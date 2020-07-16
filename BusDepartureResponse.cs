using System.Collections.Generic;
using System;

namespace Bus
{
    public class BusDepartureResponse
    {
        // Now we have got our data from our API we need to SPECIFY WHAT DATA WE WANT FROM THE JSON FILE
        //This code is designed to understand the RESPONSE (class name)/data we get from the API
        // This file is chatting to the TransportApiClient.cs file and trying to find something that matches what we have asked for here e.g. Name = match / locality = not a match so nevermind
        // This data is stored in the debugger - GET SOME HELP ON THAT 
        
        public string Name { get; set; }
        
        //We are calling the Departures object in the BusDepartureResponse Object. This will get the data below from the Departure object.
        public Departures Departures { get; set; }
        
    }

        // We also want the departure info so create another object.
        // All comes from the json file - the departure info is called ALL 
        public class Departures
        {
            public List<DepartureInfo> All { get; set; }
        }


        // Here we are displaying the important Departure info that we need from the JSON file. 
        // The Departures class calls DEPARTURE INFO in the LIST above and that list is called ALL (like the Json file)
        public class DepartureInfo
        {
            public string Line { get; set; }
            public string Direction { get; set; }
            public string ExpectedDepartureTime { get; set; }
            // the date/time doesn't have to be a string you can use a date/time type
        }



}