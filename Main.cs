using Practica_2;

namespace Practice1
{
    internal class Program
    {
        static void Main()
        {
            // Creación de taxis
            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");

            // Creación de coches de policía
            PoliceCar policeCar1 = new PoliceCar("0001 CNP");
            PoliceCar policeCar2 = new PoliceCar("0002 CNP");

            // Creación de la ciudad y la estación de policía
            City city = new City();
            PolicecarStation policecarStation = new PolicecarStation();

            // Agregar taxis a la ciudad
            city.AddTaxis(taxi1);
            city.AddTaxis(taxi2);

            // Agregar coches de policía a la estación
            policecarStation.AddpolicesCars(policeCar1);
            policecarStation.AddpolicesCars(policeCar2);

            // Mensajes de creación
            Console.WriteLine(taxi1.WriteMessage("Created"));
            Console.WriteLine(taxi2.WriteMessage("Created"));
            Console.WriteLine(policeCar1.WriteMessage("Created"));
            Console.WriteLine(policeCar2.WriteMessage("Created"));

            // Empezamos el patrullaje y el uso del radar
            Console.WriteLine("\n--- PoliceCar1 inicia patrullaje y uso del radar sobre Taxi1 ---");
            policeCar1.StartPatrolling();
            taxi1.SetSpeed(60f); // Taxi1 está excediendo el límite de velocidad
            policeCar1.UseRadar(taxi1);  // Radar detecta la velocidad de Taxi1
            policeCar1.ActivateAlarm();  // Activamos la alarma si Taxi1 excede el límite
            policeCar1.InitiatePersecution(taxi1);  // Inicia la persecución si es necesario
            policeCar1.EndPatrolling();  // Termina el patrullaje

            Console.WriteLine("\n--- PoliceCar2 revisa Taxi2 sin patrullar, luego inicia patrullaje ---");
            taxi2.SetSpeed(45f); // Taxi2 está dentro del límite
            policeCar2.UseRadar(taxi2);  // No debe activar la alarma
            policeCar2.StartPatrolling();
            taxi2.SetSpeed(70f);  // Taxi2 ahora excede el límite
            policeCar2.UseRadar(taxi2);  // Radar detecta la velocidad
            policeCar2.ActivateAlarm();  // Activamos la alarma
            policeCar2.InitiatePersecution(taxi2);  // Inicia la persecución si es necesario
            policeCar2.EndPatrolling();  // Termina el patrullaje

            // Mostrar historial de velocidades captadas por los radares
            Console.WriteLine("\n--- Historial del radar de PoliceCar1 ---");
            policeCar1.PrintRadarHistory();

            Console.WriteLine("\n--- Historial del radar de PoliceCar2 ---");
            policeCar2.PrintRadarHistory();
        }
    }
}


