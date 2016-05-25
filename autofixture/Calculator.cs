using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autofixture
{
    public class Calculator
    {
        public int Value { get; private set; }

        public void Subtract(int number)
        {
            this.Value -= number;
        }

        public void Add(int number)
        {
            this.Value += number;
        }
    }
}
