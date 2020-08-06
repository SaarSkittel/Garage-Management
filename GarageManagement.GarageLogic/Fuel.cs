using System;
namespace Ex03.GarageLogic
{
    public class Fuel : EngineType
    {

        // $G$ DSN-999 (-4) The "fuel type" field should be readonly member of class FuelEnergyProvider.
        private eFuelType m_TypeOfFuel;

        public Fuel(float i_FuelTankSize, eFuelType i_TypeOfFuel)
            : base(0f, i_FuelTankSize)
        {
            this.m_TypeOfFuel = i_TypeOfFuel;
        }

        public Fuel(Fuel i_FuelToCopy)
            : base(i_FuelToCopy.CurAmountOfFuel, i_FuelToCopy.FuelTankSize)
        {
            this.m_TypeOfFuel = i_FuelToCopy.TypeOfFuel;
        }

        public void FillFuel(eFuelType i_TypeOfFuel, float i_AmountToFill)
        {
            if (this.TypeOfFuel == i_TypeOfFuel)
            {
                this.FillPowerSource(i_AmountToFill);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public float FuelTankSize
        {
            get
            {
                return this.PowerSourceCapacity;
            }

            set
            {
                this.PowerSourceCapacity = value;
            }
        }

        public float CurAmountOfFuel
        {
            get
            {
                return this.PowerSourceState;
            }

            set
            {
                if (value > FuelTankSize || value < 0f)
                {
                    throw new ValueOutOfRangeException(FuelTankSize, 0f);
                }
                else
                {
                    this.PowerSourceState = value;
                }
            }
        }

        public eFuelType TypeOfFuel
        {
            get
            {
                return m_TypeOfFuel;
            }
        }

        public override string ToString()
        {
            return string.Format("Current amount of fuel: {0} liter.{2}type of fuel: {1}.{2}", CurAmountOfFuel, TypeOfFuel, System.Environment.NewLine);
        }
    }
}