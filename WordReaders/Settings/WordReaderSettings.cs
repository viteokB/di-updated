using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace WordReaders.Settings
{
    public record WordReaderSettings(string Path, Encoding Encoding);
}
