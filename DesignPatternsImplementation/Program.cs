namespace DesignPatternsImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Patrón creacional: Singleton!");
            Console.WriteLine();

            //MySingleton mySingleton = new MySingleton();
            MySingleton instance1 = MySingleton.GetInstance();
            Console.WriteLine($"Intancia 1: {instance1.Id}");

            MySingleton instance2 = MySingleton.GetInstance();
            Console.WriteLine($"Intancia 2: {instance2.Id}");

            MySingleton instance3 = MySingleton.GetInstance();
            Console.WriteLine($"Intancia 3: {instance3.Id}");

            MySingleton instance4 = MySingleton.GetInstance();
            Console.WriteLine($"Intancia 4: {instance4.Id}");

        }
    }
}
