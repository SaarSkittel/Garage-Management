namespace Ex03.GarageLogic
{
    public abstract class EngineType
    {
        private float m_PowerSourceCapacity;
        private float m_PowerSourceState;

        public EngineType(float i_powerSourceState, float i_PowerSourceCapacity)
        {
            this.m_PowerSourceCapacity = i_PowerSourceCapacity;
            this.m_PowerSourceState = i_powerSourceState;

        }

        public void FillPowerSource(float i_AmountToFill)
        {
            if (m_PowerSourceCapacity - m_PowerSourceState < i_AmountToFill || i_AmountToFill < 0f)
            {
                throw new ValueOutOfRangeException(m_PowerSourceCapacity - m_PowerSourceState, 0f);
            }
            else
            {
                this.m_PowerSourceState += i_AmountToFill;
            }
        }

        public float PowerSourceCapacity
        {
            get
            {
                return this.m_PowerSourceCapacity;
            }

            set
            {
                this.m_PowerSourceCapacity = value;
            }
        }

        public float PowerSourceState
        {
            get
            {
                return this.m_PowerSourceState;
            }

            set
            {
                this.m_PowerSourceState = value;
            }
        }

    }
}