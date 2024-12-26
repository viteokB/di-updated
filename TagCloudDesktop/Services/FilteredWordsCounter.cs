using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloudDesktop.Services
{
    public class FilteredWordsCounter
    {
        private readonly IEnumerable<Func<IEnumerable<string>, IEnumerable<string>>> _filterStrategies;

        public FilteredWordsCounter(IEnumerable<Func<IEnumerable<string>, IEnumerable<string>>> filterStrategies)
        {
            _filterStrategies = filterStrategies ?? throw new ArgumentNullException(nameof(filterStrategies));
        }

        public Dictionary<string, int> CountWords(IEnumerable<string> words)
        {
            if (words == null)
            {
                throw new ArgumentNullException(nameof(words), "Input words cannot be null.");
            }

            IEnumerable<string> filteredWords = words;
            foreach (var filter in _filterStrategies)
            {
                filteredWords = filter(filteredWords);
            }

            return filteredWords
                .Where(word => !string.IsNullOrWhiteSpace(word))
                .ToLookup(word => word, word => 1)
                .ToDictionary(group => group.Key, group => group.Count());
        }
    }
}
