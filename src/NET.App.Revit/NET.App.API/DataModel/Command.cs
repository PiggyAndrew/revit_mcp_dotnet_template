using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.App.API.DataModel
{
    public class Command<T>
    {
        public Command() { }

        public string Name { get; set; }

        public string Description { get; set; }

        public T Parameter { get; set; }
    }
}
