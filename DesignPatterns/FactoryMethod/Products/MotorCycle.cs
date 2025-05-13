using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryMethod.Products
{
    public class MotorCycle : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Paseando en la moto");
        }

        public void Start()
        {
            Console.WriteLine("Iniciando el paseo en la moto");
        }

        public void Stop()
        {
            Console.WriteLine("Deteniendo el paseo de la moto");
        }
    }
}
