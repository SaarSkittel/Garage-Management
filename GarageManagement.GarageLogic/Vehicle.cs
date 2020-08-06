using System;
using System.Collections.Generic;
using System.Text;
namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_Model;
        private string m_LicenseNumber;
        private float m_EnergyLeft;
        private List<Wheel> m_Wheels;
        private EngineType m_Engine;
        private int m_NumOfWheels;

        public Vehicle(string i_Model, string i_LicenseNumber, int i_NumOfWheels)
        {
            this.m_NumOfWheels = i_NumOfWheels;
            this.m_Model = i_Model;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_Wheels = new List<Wheel>(i_NumOfWheels);
        }

        public Vehicle(string i_Model, string i_LicenseNumber, int i_NumOfWheels, EngineType i_engine)
        {
            this.m_Model = i_Model;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_Wheels = new List<Wheel>(i_NumOfWheels);
            if (i_engine is Fuel)
            {
                m_Engine = new Fuel((Fuel)i_engine);
            }
            else if (i_engine is Electric)
            {
                m_Engine = new Electric((Electric)i_engine);
            }
        }

        public float EnergyLeft
        {
            get
            {
                return this.m_EnergyLeft;
            }

            set
            {
                this.m_EnergyLeft = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return this.m_Wheels;
            }

            set
            {
                this.m_Wheels = value;
            }

        }

        public string Model
        {
            get
            {
                return this.m_Model;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return this.m_LicenseNumber;
            }
        }

        public EngineType Engine
        {
            get
            {
                return this.m_Engine;

            }

            set
            {
                this.m_Engine = value;
            }
        }

        public void AddWheels(string i_Manufacturer, float i_CurAirPressure, float i_MaxAirPressure)
        {
            for (int i = 0; i < m_NumOfWheels; ++i)
            {
                m_Wheels.Add(new Wheel(i_Manufacturer, i_CurAirPressure, i_MaxAirPressure));
            }
        }

        public void UpdateAirPressure(float i_CurrentAirPressure)
        {
            for (int i = 0; i < m_NumOfWheels; ++i)
            {
                m_Wheels[i].AirPressure = i_CurrentAirPressure;
            }
        }

        public override int GetHashCode()
        {
            return this.m_LicenseNumber.GetHashCode();
        }

        public override string ToString()
        {
            string i_StrVehicle = string.Format("License number: {0},{2}Model: {1}", m_LicenseNumber, m_Model, System.Environment.NewLine);

            return i_StrVehicle;
        }
    }
}