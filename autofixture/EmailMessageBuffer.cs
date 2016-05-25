using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autofixture
{
    using System.Diagnostics;

    public class EmailMessageBuffer
    {
        public EmailMessageBuffer()
        {
            this.Emails = new List<EmailMessage>();
        }

        public List<EmailMessage> Emails { get; set; }

        public void SendAll()
        {
            foreach (var email in Emails)
            {
                Debug.WriteLine(email);
            }
        }

        public void Add(EmailMessage message)
        {
            this.Emails.Add(message);
        }
    }
}
