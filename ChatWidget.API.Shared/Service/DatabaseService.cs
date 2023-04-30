using ChatWidget.API.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.API.Shared.Service
{
    public class DatabaseService
    {
        public ChatWidgetDBContext GetDatabase()
        {
            return new ChatWidgetDBContext();
        }
    }
}
