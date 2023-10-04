using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_do_list_wpf
{
    public class Zametka
    {
        public string name;
        public string description;
        public DateTime data;
        public Zametka(string name, string description, DateTime data)
        {
            this.name = name;
            this.description = description;
            this.data = data;
        }
    }
}
