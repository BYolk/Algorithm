using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Card
    {
        public string suit;
        //public string number;
        public int number;

        /*public Card(string suit, string number)
        {
            this.suit = suit;
            this.number = number;
        }*/

        public Card(string suit, int number)
        {
            this.suit = suit;
            this.number = number;
        }

        public override string ToString()
        {
            return suit+number;
        }
    }
}
