namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer;
        private float m_AirPressure;


        // $G$ DSN-999 (-4) The "maximum air pressure" field should be readonly member of class wheel.
        private float m_MaxAirPressure;

        public Wheel(string i_Manufacturer, float i_AirPressure, float i_MaxAirPressure)
        {
            if (i_AirPressure > i_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(i_MaxAirPressure, 0);
            }

            this.m_Manufacturer = i_Manufacturer;
            this.m_AirPressure = i_AirPressure;
            this.m_MaxAirPressure = i_MaxAirPressure;
        }

        public void FillAirToMax()
        {
            this.AirPressure = this.MaxAirPressure;
        }

        public string Manufacturer
        {
            get
            {
                return this.m_Manufacturer;

            }

            set
            {
                this.m_Manufacturer = value;
            }
        }

        public float AirPressure
        {
            get
            {
                return this.m_AirPressure;
            }

            set
            {
                if (value > m_MaxAirPressure || value < 0f)
                {
                    throw new ValueOutOfRangeException(m_MaxAirPressure, 0f);
                }
                else
                {
                    this.m_AirPressure = value;
                }
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return this.m_MaxAirPressure;
            }

            set
            {
                this.m_MaxAirPressure = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Wheel manufacturer: {0},{2}Current air pressure: {1},{2}", m_Manufacturer, m_AirPressure, System.Environment.NewLine);
        }
    }
}