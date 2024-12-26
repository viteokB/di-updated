using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleClient.Services;

namespace ConsoleClient.Interfaces
{
    public interface ISettingsProvider
    {
        public SettingsStorage GetSettingsStorage();
    }
}
