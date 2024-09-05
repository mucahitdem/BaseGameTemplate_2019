using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Random = System.Random;

namespace GAME.Scripts.Helpers
{
    public static class HelperMethods
    {
        public static List<T> SelectRandomElementsToList<T>(List<T> originalList, int count)
        {
            if (count > originalList.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count cannot be greater than the number of elements in the list.");
            }

            Random rng = new Random();
            List<T> tempList = new List<T>(originalList);
            List<T> resultList = new List<T>();

            for (int i = 0; i < count; i++)
            {
                int randomIndex = rng.Next(tempList.Count);
                resultList.Add(tempList[randomIndex]);
                tempList.RemoveAt(randomIndex);
            }

            return resultList;
        }
        
        public static T[] SelectRandomElementsToArray<T>(T[] originalList, int count)
        {
            if (count > originalList.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count cannot be greater than the number of elements in the list.");
            }

            Random rng = new Random();
            List<T> tempList = new List<T>(originalList);
            T[] resultList = new T[count];

            for (int i = 0; i < count; i++)
            {
                int randomIndex = rng.Next(tempList.Count);
                resultList[i] = tempList[randomIndex];
                tempList.RemoveAt(randomIndex);
            }

            return resultList;
        }
        
        public static string ConvertToTimeString(int totalSeconds)
        {
            int hours = (totalSeconds / 3600) % 24;
            int minutes = (totalSeconds % 3600) / 60;
            //int seconds = totalSeconds % 60;

            return $"{hours:00}:{minutes:00}";
        }
        
        public static string ConvertToTimeStringInMinutes(int totalSeconds)
        {
            int minutes = (totalSeconds % 3600) / 60;
            int seconds = totalSeconds % 60;

            return $"{minutes:00}:{seconds:00}";
        }
        
        public static T FindComponentInChildren<T>(GameObject parent) where T : MonoBehaviour
        {
            if (parent == null)
                return null;

            // Check if the parent has the component
            T component = parent.GetComponent<T>();
            if (component != null)
                return component;

            // Recursively check each child
            foreach (Transform child in parent.transform)
            {
                component = FindComponentInChildren<T>(child.gameObject);
                if (component != null)
                    return component;
            }

            // Return null if the component was not found
            return null;
        }
        
        public static string ConvertToReadable(string input)
        {
            // Add a space before each uppercase letter and trim any leading spaces
            string result = Regex.Replace(input, "(\\B[A-Z])", " $1");

            // Capitalize the first letter of each word
            result = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(result.ToLower());

            return result;
        }
    }
}