using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice1;

namespace Practica_2
{
    public class City
    {
        private PolicecarStation policecarstation;
        public List<string> taxisList = new List<string>();
        public City()
        {
            policecarstation = new PolicecarStation();
        }

        public void AddTaxis(Vehicle vehicle)
        {
            if (!taxisList.Contains(vehicle.GetPlate()))
            {
                taxisList.Add(vehicle.GetPlate());

                foreach (string taxis in taxisList)
                {
                    Console.WriteLine(taxis);
                }
            }
        }
    }
}

