using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Adress
    {
        private string city;
        private string street;
        private int nHouse;
        public string City {get { return city; }set { city = value; }}
        public string Street { get { return street; } set { street = value; } }
        public int NHouse {get { return nHouse; }set { nHouse = value; }}
        public Adress(string City, string Street, int NHouse)
        {
            city = City;
            street = Street;
            nHouse = NHouse;
        }
        public string AddresToString()
        {
            return (city + " " + street + " " + nHouse.ToString());
        }
    }
}
