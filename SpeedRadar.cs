namespace Practice1
{
    public class SpeedRadar : IMessageWritter
    {
        //Radar doesn't know about Vechicles, just speed and plates
        private string plate;
        private float speed;
        private float legalSpeed = 50.0f;
        public List<float> SpeedHistory { get; private set; }
        public List<string> SpeedingVehicles { get; private set; }

        public SpeedRadar()
        {
            plate = "";
            speed = 0f;
            SpeedHistory = new List<float>();
            SpeedingVehicles = new List<string>();
        }

        public void TriggerRadar(Vehicle vehicle)
        {
            plate = vehicle.GetPlate();
            speed = vehicle.GetSpeed();
            SpeedHistory.Add(speed);
            if (speed > legalSpeed)
            {
                SpeedingVehicles.Add(plate);  // Guardamos la matrícula si excede la velocidad
            }
        }

        public bool GetLastReading2()
        {
            if (speed > legalSpeed)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetLastReading()
        {
            if (speed > legalSpeed)
            {

                return WriteMessage("Catched above legal speed.");
            }
            else
            {
                return WriteMessage("Driving legally.");
            }
        }

        public virtual string WriteMessage(string radarReading)
        {
            return $"Vehicle with plate {plate} at {speed.ToString()} km/h. {radarReading}";
        }
    }
}