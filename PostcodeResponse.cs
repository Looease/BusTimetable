using System.Collections.Generic;
using System;

namespace Bus
{
    public class PostcodeResponse
    {
        //in C# it is convention to start in caps even though in Json RESULT is lowercase
        public Coordinates Result {get; set;}
    }

    public class Coordinates
    
    {
        public double Longitude {get; set;}

        public double Latitude {get; set;}


    }

}