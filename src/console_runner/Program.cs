﻿using System;
using YSQ.core;

namespace YSQ.console_runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var quote_service = new QuoteService();
            var quotes = quote_service.Quote("MSFT", "GOOG").Return(QuoteReturnParameter.Symbol,
                                                                    QuoteReturnParameter.Name,
                                                                    QuoteReturnParameter.LatestTradePrice,
                                                                    QuoteReturnParameter.LatestTradeTime);

            foreach (var quote in quotes)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", quote.Symbol, quote.Name, quote.LatestTradePrice, quote.LatestTradeTime);
            }

            Console.ReadLine();
        }
    }
}