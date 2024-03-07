using System.Collections.Generic;

namespace Helpers
{
    public static class CustomMathFunctions
    {
        public static List<float> CalculateColumnPositions(int columnsAmount, float distanceBetweenColumns)
        {
            var rowsPositions = new List<float>(columnsAmount);

            float center = 0;
            float left = center - distanceBetweenColumns * (columnsAmount / 2);

            if (columnsAmount % 2 == 0)
            {
                left -= distanceBetweenColumns / 2;
            }

            for (int i = 0; i < columnsAmount; i++)
            {
                rowsPositions.Add(left);
                left += distanceBetweenColumns;
            }

            return rowsPositions;
        }
    }
}
