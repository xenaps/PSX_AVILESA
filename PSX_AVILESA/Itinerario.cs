using System;
using System.Collections.Generic;

namespace PSX_AVILESA
{
    public class Itinerario
    {
        public List<Parada> Paradas { get; set; }

        public Itinerario()
        {
            Paradas = new List<Parada>();
        }
    }
}