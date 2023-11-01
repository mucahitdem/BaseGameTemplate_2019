using UnityEngine;

namespace Scripts.GameScripts.RateCalculatorManagement
{
    public class RateCalculator
    {
        private readonly RateCalculatorData _data;

        public RateCalculator(RateCalculatorData data)
        {
            _data = data;
        }

        public float CalculateRate(float currentValue)
        {
            var normalizedInput = (currentValue - _data.minInput) / (_data.maxInput - _data.minInput);
            var currentOutput = Mathf.Lerp(_data.minOutput, _data.maxOutput, normalizedInput);

            return currentOutput;
        }
    }
}