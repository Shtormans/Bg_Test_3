using System.Collections.Generic;
using UnityEngine;

namespace Helpers
{
    public static class RandomChoiceMaker
    {
        public static T MakeChoiceWithChances<T>(RandomChoiceObject<T>[] values, T defaultValue = default)
        {
            var randomValue = Random.Range(0f, 1f);

            double chanceSum = 0;

            foreach (var value in values)
            {
                chanceSum += value.Chances;

                if (randomValue <= chanceSum)
                {
                    return value.Value;
                }
            }

            return defaultValue;
        }

        public static T MakeChoice<T>(T[] values)
        {
            int randomIndex = Random.Range(0, values.Length);

            return values[randomIndex];
        }

        public static List<T> PickDifferentItems<T>(T[] values, int amount)
        {
            if (amount <= 0 || amount > values.Length)
            {
                return default;
            }

            bool[] valueIsTaken = new bool[values.Length];
            List<T> result = new List<T>(amount);

            for (int i = 0; i < amount; i++)
            {
                int randomIndex = Random.Range(0, values.Length);

                while (valueIsTaken[randomIndex])
                {
                    randomIndex = (randomIndex + 1) % values.Length;
                }

                result.Add(values[randomIndex]);
                valueIsTaken[randomIndex] = true;
            }

            return result;
        }
    }
}