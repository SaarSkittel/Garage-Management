namespace Ex03.GarageLogic
{
    public class Electric : EngineType
    {
        public Electric(float i_MaxTimeOfBattery)
            : base(0f, i_MaxTimeOfBattery)
        {

        }

        public Electric(Electric i_ElectricToCopy)
            : base(i_ElectricToCopy.CurTimeOfBatteryUse, i_ElectricToCopy.MaxTimeOfBattery)
        {

        }

        public void ChargeBattrey(float i_AmountToCharge)
        {
            this.FillPowerSource(i_AmountToCharge);
        }

        public float MaxTimeOfBattery
        {
            get
            {
                return this.PowerSourceCapacity;
            }
        }

        public float CurTimeOfBatteryUse
        {
            get
            {
                return this.PowerSourceState;
            }

            set
            {
                if (value > MaxTimeOfBattery || value < 0f)
                {
                    throw new ValueOutOfRangeException(MaxTimeOfBattery, 0f);
                }
                else
                {
                    this.PowerSourceState = value;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("Current battery power: {0} hours{1}", CurTimeOfBatteryUse, System.Environment.NewLine);
        }
    }
}