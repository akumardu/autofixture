using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autofixture
{
    public class FlightDetails
    {
        private string arrivalAirportCode;

        private string departureAirportCode;

        public FlightDetails()
        {
            this.MealOptions = new List<string>();
        }

        public string DepartureAirportCode
        {
            get { return this.departureAirportCode; }
            set
            {
                this.EnsureValidAirportCode(value);
                this.departureAirportCode = value;
            }
        }

        public string ArrivalAirportCode
        {
            get { return this.arrivalAirportCode; }
            set
            {
                this.EnsureValidAirportCode(value);
                this.arrivalAirportCode = value;
            }
        }

        public TimeSpan FlightDuration { get; set; }
        public string AirlineName { get; set; }
        public List<string> MealOptions { get; set; }

        private void EnsureValidAirportCode(string airportCode)
        {
            var isWrongLength = airportCode.Length != 3;
            var isWrongCase = airportCode != airportCode.ToUpperInvariant();

            if (isWrongCase || isWrongLength)
            {
                throw new ApplicationException(airportCode + " is an invalid airpot");
            }
        }
    }
}
