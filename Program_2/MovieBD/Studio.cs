using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBD
{
    public class Studio
    {
        private int _id;
        private string _name;
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public Studio(int id, string name)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            _id = id;
            _name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}