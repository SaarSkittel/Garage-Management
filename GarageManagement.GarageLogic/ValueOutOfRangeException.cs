using System;
namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
           : base()
        {
            this.m_MaxValue = i_MaxValue;
            this.m_MinValue = i_MinValue;
        }

        public float MaxValue
        {
            get
            {
                return this.m_MaxValue;
            }
        }

        public float MinValue
        {
            get
            {
                return this.m_MinValue;
            }
        }
    }
}