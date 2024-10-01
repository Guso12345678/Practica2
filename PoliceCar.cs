namespace Practice1
{
    public class PoliceCar : Vehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car";
        private bool isPatrolling;
        private bool isPersecution;
        private SpeedRadar speedRadar;
        private PolicecarStation policecarStation;

        public PoliceCar(string plate) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            isPersecution = false;
            speedRadar = new SpeedRadar();
            policecarStation = new PolicecarStation();
        }

        public void UseRadar(Vehicle vehicle)
        {
            if (isPatrolling)
            {
                speedRadar.TriggerRadar(vehicle);
                string meassurement = speedRadar.GetLastReading();
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }
        public void PrintRadarHistory()
        {
            Console.WriteLine(WriteMessage("Report radar speed history:"));
            foreach (float speed in speedRadar.SpeedHistory)
            {
                Console.WriteLine(speed);
            }
        }
        public void ActivateAlarm()
        {
            if (speedRadar.GetLastReading2() == true)
            {
                policecarStation.Alert = true;

                foreach (string plate in speedRadar.SpeedingVehicles)
                {
                    Console.WriteLine($"{plate} are fugitives");
                }
            }
        }
        public void InitiatePersecution(Vehicle vehicle)
        {
            if (policecarStation.Alert == true & isPatrolling == true & speedRadar.SpeedingVehicles.Contains(vehicle.GetPlate()) & isPersecution == false)
            {
                isPersecution = true;
                Console.WriteLine($"Se inicia una persecucion a : {vehicle.GetPlate()}");
            }
            else
            {
                isPersecution = false;
                Console.WriteLine($"No se puede iniciar una persecucion");
            }
        }
    }
}