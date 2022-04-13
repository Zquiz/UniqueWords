using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqueWords.Core.Models;
using UniqueWords.Database;
using UniqueWords.Database.Models;

namespace UniqueWords.Core.Services
{
    public class UniqueWordService
    {
        private readonly UniqueWordContext _context;

        public UniqueWordService(UniqueWordContext context)
        {
            _context = context;
        }
        public async Task<ResponseDTO> UniqueCount(string text)
        {
            var result = new ResponseDTO();

            var listWords = text.Split(' ')
                .GroupBy(x => x.ToLower())
                .Select(x =>  new UniqueWordList()
                { UniqueWordName = x.Key})         
                .ToList();

            _context.BulkInsert(listWords, x =>
                {
                    x.InsertIfNotExists = true;
                    x.ColumnPrimaryKeyExpression = c => c.UniqueWordName;
                });


            result.DistinctUniqueWords = await _context.UniqueWordList.CountAsync();
            result.WatchlistWords = await _context.WatchList.Where(x => listWords.Select(y => y.UniqueWordName).Contains(x.WatchedWord)).Select(x => x.WatchedWord).ToArrayAsync();
            return result;
        }
        public void AddWatchlistWord(AddWatchlistWordDTO model)
        {
            if (!string.IsNullOrWhiteSpace(model.Word))
            {
                var words = model.Word.Split(' ')
                     .GroupBy(x => x.ToLower())
                    .Select(x => new WatchList()
                    { WatchedWord = x.Key })
                    .Distinct()
                    .ToList();
                _context.BulkInsert(words, x =>
                {
                    x.InsertIfNotExists = true;
                    x.ColumnPrimaryKeyExpression = c => c.WatchedWord;
                });
            }
        }

    }
}
