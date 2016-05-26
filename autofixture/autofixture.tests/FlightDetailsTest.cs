using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace autofixture.tests
{
    using Ploeh.AutoFixture;

    [TestClass]
    public class FlightDetailsTest
    {
        [TestMethod]
        public void TestBasicInjection()
        {
            var fixture = new Fixture();

            // Sets all string instances to the given string
            fixture.Inject("LHR");
            var flight = fixture.Create<FlightDetails>();


            

            

           


        }

        [TestMethod]
        public void TestObjectInjection()
        {
            var fixture = new Fixture();

            // Sets all object instances to the given instance
            fixture.Inject(
                new FlightDetails
                {
                    DepartureAirportCode = "HEL",
                    ArrivalAirportCode = "BEL",
                    FlightDuration = TimeSpan.FromHours(1),
                    AirlineName = "AKD airs"
                }
                );

            var flights = fixture.CreateMany<FlightDetails>();
        }

        [TestMethod]
        public void TestOmitSpecificProperties()
        {
            var fixture = new Fixture();

            // Do not create specific properties
            var flightWithoutSpecificProperties = fixture.Build<FlightDetails>()
                .Without(x => x.ArrivalAirportCode)
                .Without(x => x.DepartureAirportCode)
                .Create();

        }

        [TestMethod]
        public void TestOmitAllAutomaticProperties()
        {
            var fixture = new Fixture();

            // Omits all automatic properties
            var flightWithoutAutoProperties = fixture.Build<FlightDetails>()
                .OmitAutoProperties()
                .Create();
        }

        [TestMethod]
        public void TestCustomizedBuilding()
        {
            var fixture = new Fixture();

            // Add some properties
            var flightWithCustomizedProperties = fixture.Build<FlightDetails>()
                .With(x => x.ArrivalAirportCode, "LAZ")
                .With(x => x.DepartureAirportCode, "LHR")
                .Create();
        }

        [TestMethod]
        public void TestCustomizedBuildingWithActions()
        {
            var fixture = new Fixture();

            // Use functions to add properties
            var flightWithCustomizedProperties = fixture.Build<FlightDetails>()
                .With(x => x.ArrivalAirportCode, "LAZ")
                .With(x => x.DepartureAirportCode, "LHR")
                .Without(x => x.MealOptions)
                .Do(x => x.MealOptions.Add("Chicken"))
                .Do(x => x.MealOptions.Add("Fish"))
                .Create();
        }

        [TestMethod]
        public void TestCustomSpecimenBuilder()
        {
            var fixture = new Fixture();

            // use Custom Specimen Builder
            fixture.Customizations.Add(new AirportCodeSpecimenBuilder());
            var flight = fixture.Create<FlightDetails>();
        }
    }
}
