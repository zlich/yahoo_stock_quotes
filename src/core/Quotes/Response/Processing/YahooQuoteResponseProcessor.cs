using System.Collections.Generic;
using System.Linq;
using YSQ.core.Quotes.Request.Processing;

namespace YSQ.core.Quotes.Response.Processing
{
    public class YahooQuoteResponseProcessor : IProcessAQuoteResponse
    {
        IParseACsvResponse csv_response_parser;
        IParseAYahooQuote yahoo_quote_parser;

        public YahooQuoteResponseProcessor(IParseACsvResponse csv_response_parser, IParseAYahooQuote yahoo_quote_parser)
        {
            this.csv_response_parser = csv_response_parser;
            this.yahoo_quote_parser = yahoo_quote_parser;
        }

        public IEnumerable<dynamic> Return(QuoteResponse quote_response)
        {
            return csv_response_parser.Parse(quote_response.WebResponse).Select(yahoo_quote => yahoo_quote_parser.Parse(yahoo_quote, quote_response.QuoteRequest.ReturnParameters));
        }
    }
}