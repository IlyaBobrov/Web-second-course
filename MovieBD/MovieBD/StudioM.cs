using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBD
{
    public class StudioManager
    {
        public HashSet<Genre> Studios { get; set; }

        public StudioManager()
        {
            Studios = new HashSet<Genre>();
        }
        public int Add(string name)
        {
            int id;
            if (Studios.Any(p => p.Name == name))
            {
                var first = Studios.FirstOrDefault(p => p.Name == name);
                if (first == null)
                {
                    Console.WriteLine("!!! id is null");
                    return -1;
                }
                else
                {
                    id = first.Id;
                    Console.WriteLine("!!! " + name + " already exists... Id: " + id);
                    return id;
                }
            }

            id = Studios.Count;
            Studios.Add(new Genre(id, name));
            Console.WriteLine("OK| id: " + id + "\t | " + name + " " + " added***");
            return id;
        }
        public Genre GetName(string name) => Studios.FirstOrDefault(p => p.Name == name);
        public Genre GetId(int id) => Studios.FirstOrDefault(p => p.Id == id);
        public void GetAllStudios(HashSet<int> idStudios)
        {
            Console.WriteLine("\nStudios:");
            foreach (var p in idStudios)
            {
                Console.WriteLine("id: " + p + "\t | " + GetId(p).Name);
            }
            Console.WriteLine("----");
        }
    }
}