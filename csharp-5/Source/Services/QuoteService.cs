using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;

        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        public Quote GetAnyQuote()
        {
            List<Quote> quotes = _context.Quotes.ToList();
            if (quotes.Count() == 0)
            {
                return null;
            }
            return quotes[_randomService.RandomInteger(quotes.Count())];
        }

        public Quote GetAnyQuote(string actor)
        {
            List<Quote> quotesOfActor = _context.Quotes.Where(q => q.Actor == actor).ToList();
            if (quotesOfActor.Count() == 0)
            {
                return null;
            }
            return quotesOfActor[_randomService.RandomInteger(quotesOfActor.Count())];
        }
    }
}