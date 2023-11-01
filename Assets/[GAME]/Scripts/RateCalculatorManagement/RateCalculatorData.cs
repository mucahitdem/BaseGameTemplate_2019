using System;

namespace Scripts.GameScripts.RateCalculatorManagement
{
    [Serializable]
    public class RateCalculatorData
    {
        public float maxInput;
        public float maxOutput;
        public float minInput;
        public float minOutput;

        public RateCalculatorData(float minInput, float maxInput, float minOutput, float maxOutput)
        {
            this.minInput = minInput;
            this.maxInput = maxInput;
            this.minOutput = minOutput;
            this.maxOutput = maxOutput;
        }
    }
}