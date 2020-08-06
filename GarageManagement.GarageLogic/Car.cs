namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eNumOfDoors m_DoorsNumber;
        private eColor m_CarColor;

        public Car(string i_Model, string i_LicenseNumber, string i_Manufacturer, float i_CurAirPressure)
          : base(i_Model, i_LicenseNumber, 4)
        {
            AddWheels(i_Manufacturer, i_CurAirPressure, 32f);
        }

        public Car(Car i_CarToCopy)
            : base(i_CarToCopy.Model, i_CarToCopy.LicenseNumber, 4, i_CarToCopy.Engine)
        {
            this.m_DoorsNumber = i_CarToCopy.DoorsNumber;
            this.m_CarColor = i_CarToCopy.CarColor;
            foreach (Wheel w in i_CarToCopy.Wheels)
            {
                this.Wheels.Add(w);
            }
        }

        public eNumOfDoors DoorsNumber
        {
            get
            {
                return this.m_DoorsNumber;
            }

            set
            {
                this.m_DoorsNumber = value;
            }
        }

        public eColor CarColor
        {
            get
            {
                return this.m_CarColor;
            }

            set
            {
                this.m_CarColor = value;
            }
        }

        public override string ToString()
        {
            string i_strCar = string.Format("{0},{3}number of doors: {1},{3}color: {2},{3}", base.ToString(), m_DoorsNumber, m_CarColor, System.Environment.NewLine);
            if (this.Engine is Fuel)
            {
                i_strCar += ((Fuel)this.Engine).ToString();
            }
            else
            {
                i_strCar += ((Electric)this.Engine).ToString();
            }

            int i = 1;
            foreach (Wheel w in this.Wheels)
            {
                i_strCar += string.Format("Wheel number {0}:{1}{2}", i++, System.Environment.NewLine, w.ToString());
            }

            return i_strCar;
        }

    }
}