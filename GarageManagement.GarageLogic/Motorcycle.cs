namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private int m_EngineCapacity;
        private eLicenseType m_TypeOfLicense;

        public Motorcycle(string i_Model, string i_LicenseNumber, string i_Manufacturer, float i_CurAirPressure)
          : base(i_Model, i_LicenseNumber, 2)
        {
            AddWheels(i_Manufacturer, i_CurAirPressure, 30f);
        }

        public Motorcycle(Motorcycle i_MotorcycleToCopy)
             : base(i_MotorcycleToCopy.Model, i_MotorcycleToCopy.LicenseNumber, 2, i_MotorcycleToCopy.Engine)
        {
            this.m_EngineCapacity = i_MotorcycleToCopy.EngineCapacity;
            this.m_TypeOfLicense = i_MotorcycleToCopy.TypeOfLicense;
            foreach (Wheel w in i_MotorcycleToCopy.Wheels)
            {
                this.Wheels.Add(w);
            }
        }

        public int EngineCapacity
        {
            get
            {
                return this.m_EngineCapacity;
            }

            set
            {
                if(value <= 0f)
                {
                    throw new ValueOutOfRangeException(0f, 0f);
                }
                else
                {
                    this.m_EngineCapacity = value;
                }
            }
        }

        public eLicenseType TypeOfLicense
        {
            get
            {
                return this.m_TypeOfLicense;
            }

            set
            {
                this.m_TypeOfLicense = value;
            }
        }

        public override string ToString()
        {
            string i_strMotorcycle = string.Format("{0},{3}engine capacity: {1},{3}type license: {2}{3}", base.ToString(), m_EngineCapacity, m_TypeOfLicense, System.Environment.NewLine);
            if (this.Engine is Fuel)
            {
                i_strMotorcycle += ((Fuel)this.Engine).ToString();
            }
            else
            {
                i_strMotorcycle += ((Electric)this.Engine).ToString();
            }
            int i = 1;
            foreach (Wheel w in this.Wheels)
            {
                i_strMotorcycle += string.Format("Wheel number {0}:{1}{2}", i++, System.Environment.NewLine, w.ToString());
            }
            return i_strMotorcycle;
        }
    }
}