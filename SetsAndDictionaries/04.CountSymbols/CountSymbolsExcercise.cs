﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CountSymbols
{
    public class CountSymbolsExcercise
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var symbolsInfo = new SortedDictionary<char, long>();

            foreach (var symbol in text)
            {
                if (symbolsInfo.ContainsKey(symbol))
                {
                    ++symbolsInfo[symbol];
                }
                else
                {
                    symbolsInfo.Add(symbol, 1L);
                }
            }

            foreach (var symbolInfo in symbolsInfo)
            {
                Console.WriteLine($"{symbolInfo.Key}: {symbolInfo.Value} time/s");
            }
        }
    }
}
