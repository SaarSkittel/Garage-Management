namespace Ex03.GarageLogic
{
    public class Customer
    {
        private string m_OwnerName;
        private string m_OwnerPhone;
        private eStatus m_Status;
        private Vehicle m_Vehicle;

        public Customer(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            this.m_OwnerName = i_OwnerName;
            this.m_OwnerPhone = i_OwnerPhone;
            this.m_Status = eStatus.InRepair;
            if (i_Vehicle is Car)
            {
                m_Vehicle = new Car((Car)i_Vehicle);
            }
            else if (i_Vehicle is Motorcycle)
            {
                m_Vehicle = new Motorcycle((Motorcycle)i_Vehicle);
            }
            else if (i_Vehicle is Truck)
            {
                m_Vehicle = new Truck((Truck)i_Vehicle);
            }
        }

        public eStatus Status
        {
            get
            {
                return this.m_Status;
            }

            set
            {
                this.m_Status = value;
            }
        }

        public string OwnerName
        {
            get
            {
                return this.m_OwnerName;
            }
        }

        public Vehicle CustomerVehicle
        {
            get
            {
                return this.m_Vehicle;
            }

            set
            {
                this.m_Vehicle = value;
            }
        }

        public string OwnerPhone
        {
            get
            {
                return this.m_OwnerPhone;
            }
        }

        public override string ToString()
        {
            return string.Format("Owner Name:{0},{4}Owner phone:{1},{4}status:{2},{4}{3}", m_OwnerName, m_OwnerPhone, m_Status, m_Vehicle.ToString(), System.Environment.NewLine);
        }
    }
}