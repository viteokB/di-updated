using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordHandlers.MyStem.InfoClasses;

namespace WordHandlers.Handlers
{
    public static class NotBoringConfiguration
    {
        public static HashSet<PartOfSpeech> NotBoringPartOfSpeeches =>
        [
            PartOfSpeech.A,
            PartOfSpeech.V,
            PartOfSpeech.S
        ];
    }
}
