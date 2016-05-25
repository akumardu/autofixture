using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autofixture
{
    public class EmailMessage
    {
        public string SomePublicField;

        private string somePrivateField;

        private string SomePrivateProperty { get; set; }

        public EmailMessage(string inputa, string inputb)
        {
            this.somePrivateField = inputa;
            this.SomePrivateProperty = inputb;
            this.SomePublicField = inputa + inputb;
        }
    }
}
