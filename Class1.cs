using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace RomanCalculator
{
    public class RomanCalculator
    {
        private static readonly Dictionary<char, int> RomanValues = new Dictionary<char, int>
        {
            {'I',1 },
            {'V', 5 },
            {'X', 10},
            {'L', 50 },
            {'C', 100 },
            {'D', 500 },
            {'M', 1000 }

        };

        public string Add(string roman1, string roman2)
        {
            int num1 = RomanToDecimal(roman1);
            int num2 = RomanToDecimal(roman2);
            int sum = num1 + num2;
            return DecimalToRoman(sum);
        
        }

        private int RomanToDecimal(string roman) 
        {
            int result = 0;
            int prevValue = 0;

            foreach(char c in Reverse(roman))
            {
                int value = RomanValues[c];
                if (value < prevValue)
                
                    result -= value;
                
                else
                    result += value;
                   prevValue = value;
            }
            return result; 
        }

        private string DecimalToRoman(int num)
        {
            if (num <= 0)
                throw new ArgumentOutOfRangeException(nameof(num), "Roman numerals cannot represent non positive numbers");
            StringBuilder result = new StringBuilder();

            // Definir los simbolos romanos y sus valores 
            string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            int[] values = { 1000, 900, 500, 400, 100, 90, 10, 9, 5, 4, 1 };
            
            // conversion de numeros decimales a romanos 
            for( int i =0; i< symbols.Length; i++ )
            { 
                while(num >= values[i])
                {
                    result.Append(symbols[i] );
                    num -= values[i];   
                }
            
            }

            return result.ToString();
        }

        private static IEnumerable<T> Reverse<T>(IEnumerable<T> input)
        {
            var stack = new Stack<T>();
            foreach (var item in input)
                stack.Push(item);
                 return stack;
        }
    }  
}
