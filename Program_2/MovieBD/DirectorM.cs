using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace MovieBD
{
    public class DirectorManager
    {
        
        private HashSet<Director> _dir;

        public HashSet<Director> Directors
        {
            get => _dir;
            set => _dir = value;            
        }

        public DirectorManager()
        {
            Directors = new HashSet<Director>();
        }

        public int Add(string name)
        {
            int id;
            if (Directors.Any(p => p.Name == name))
            {
                var first = Directors.FirstOrDefault(p => p.Name == name);
                if (first == null)
                {
                    Console.WriteLine("! id is null");
                    return -1;
                }
                else
                {
                    id = first.Id;
                    Console.WriteLine("! " + name + " already exists... Id: " + id);
                    return id;
                }
            }
            id = Directors.Count;
            Directors.Add(new Director(id, name));

            Console.WriteLine("ADD| id: " + id +" - " + name );
            return id;
        }
        public Director GetId(int id) => Directors.FirstOrDefault(p => p.Id == id);
        public Director GetName(string name) => Directors.FirstOrDefault(p => p.Name == name);
        public void GetAllDirectors(HashSet<int> idDirectors)
        {
            Console.WriteLine("\nDirectors:");
            foreach (var p in idDirectors)
            {
                Console.WriteLine("id: " + p + " - " + GetId(p).Name );
            }
            Console.WriteLine("--OK--");
        }
    }
}