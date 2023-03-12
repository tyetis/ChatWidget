using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget
{
    public class Config
    {
        public string DataPath { get; set; }

        public Config(IConfiguration configuration)
        {
            DataPath = configuration.GetSection("DataPath").Value;
        }
        public Config() { }
    }
}
