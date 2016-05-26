using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autofixture.tests
{
    using System.Reflection;

    using Ploeh.AutoFixture.Kernel;

    public class AirportCodeSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            // See if we are trying to create a value for a property
            var propertyInfo = request as PropertyInfo;

            if (propertyInfo == null)
            {
                // this customization doesn't apply to current request;
                return new NoSpecimen();
            }

            // We are dealing with a property
            // Are we creating a value for an airport code?
            var isAirportCodeProperty = propertyInfo.Name.Contains("AirportCode") &&
                                        propertyInfo.PropertyType == typeof(string);

            if (isAirportCodeProperty)
            {
                return this.RandomAirportCode();
            }

            return new NoSpecimen();
        }

        private string RandomAirportCode()
        {
            if (DateTime.Now.Ticks % 2 == 0)
            {
                return "AAA";
            }

            return "BBB";
        }
    }
}
