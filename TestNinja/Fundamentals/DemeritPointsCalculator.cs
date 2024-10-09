using System;

namespace TestNinja.Fundamentals
{
    public class DemeritPointsCalculator
    {
        private const int SpeedLimit = 65;
        private const int MaxSpeed = 300;

        public int CalculateDemeritPoints(int speed)
        {
            bool isSpeedPossitive = speed < 0,
                isSpeedExceedMaxSpeed = speed > MaxSpeed,
                isSpeedIsBelowOrEqualSpeedLimit = speed <= SpeedLimit;

            if (isSpeedPossitive || isSpeedExceedMaxSpeed)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (isSpeedIsBelowOrEqualSpeedLimit)
            {
                return 0;
            }

            const int kmPerDemeritPoint = 5;
            int demeritPoints = (speed - SpeedLimit) / kmPerDemeritPoint;

            return demeritPoints;
        }
    }
}