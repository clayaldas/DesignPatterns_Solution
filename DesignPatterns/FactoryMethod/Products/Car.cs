using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryMethod.Products
{
    public class Car : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Paseando en el auto");
        }

        public void Start()
        {
            Console.WriteLine("Iniciando el paseo en el auto");
        }

        public void Stop()
        {
            Console.WriteLine("Deteniendo el paseo en el auto");
        }
    }
}
