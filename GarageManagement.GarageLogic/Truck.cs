using System;
namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_DeliversDangerousChemicals;
        private float m_TrunkSize;

        public Truck(string i_Model, string i_LicenseNumber, string i_Manufacturer, float i_CurAirPressure)
          : base(i_Model, i_LicenseNumber, 16)
        {
            AddWheels(i_Manufacturer, i_CurAirPressure, 28f);
        }

        public Truck(Truck i_TruckToCopy)
               : base(i_TruckToCopy.Model, i_TruckToCopy.LicenseNumber, 16, i_TruckToCopy.Engine)
        {
            this.m_DeliversDangerousChemicals = i_TruckToCopy.DeliversDangerousChemicals;
            this.m_TrunkSize = i_TruckToCopy.TrunkSize;
            foreach (Wheel w in i_TruckToCopy.Wheels)
            {
                this.Wheels.Add(w);
            }
        }

        public bool DeliversDangerousChemicals
        {
            get
            {
                return this.m_DeliversDangerousChemicals;
            }

            set
            {
                this.m_DeliversDangerousChemicals = value;
            }
        }

        public float TrunkSize
        {
            get
            {
                return this.m_TrunkSize;
            }

            set
            {
                if (value <= 0f)
                {
                    throw new ValueOutOfRangeException(0f, 0f);
                }
                else
                {
                    this.m_TrunkSize = value;
                }
            }
        }

        public override string ToString()
        {
            string i_strTruck = string.Format("{0},{3}delivers dangerous chemicals: {1},{3}trunk size: {2}{3}", base.ToString(), m_DeliversDangerousChemicals, m_TrunkSize, System.Environment.NewLine);
            i_strTruck += ((Fuel)this.Engine).ToString();
            int i = 1;
            foreach (Wheel w in this.Wheels)
            {
                i_strTruck += string.Format("Wheel number {0}:{1}{2}", i++, System.Environment.NewLine, w.ToString());
            }

            return i_strTruck;
        }
    }
}