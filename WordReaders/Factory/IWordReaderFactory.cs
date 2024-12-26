using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordReaders.Settings;

namespace WordReaders.Factory
{
    public interface IWordReaderFactory
    {
        public IWordReader CreateWordReader(WordReaderSettings settings);
    }
}
