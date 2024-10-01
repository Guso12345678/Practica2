namespace Practice1
{
    public class PolicecarStation
    {
        private bool alert = false;
        public List<string> polices_cars = new List<string>();
        private double legalSpeed;
        private SpeedRadar speedRadar;
        public PolicecarStation()
        {
            speedRadar = new SpeedRadar();
        }
        public bool Alert
        {
            get { return alert; }
            set { alert = value; }
        }
        public double LegalSpeed
        {
            get { return legalSpeed; }
            set { legalSpeed = value; }
        }
        public void AddpolicesCars(Vehicle vehicle)
        {
            polices_cars.Add(vehicle.GetPlate());
        }
    }
}

