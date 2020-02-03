using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace MovieBD
{
    public class GenreManager
    {
        public HashSet<Genre> Genres { get; set; }

        public GenreManager()
        {
            Genres = new HashSet<Genre>();
        }
        public int Add(string name)
        {
            int id;
            if (Genres.Any(p => p.Name == name))
            {

                var first = Genres.FirstOrDefault(p => p.Name == name);
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

            id = Genres.Count;
            Genres.Add(new Genre(id, name));
            Console.WriteLine("ADD| id: " + id + " - " + name );
            return id;
        }
        public Genre GetName(string name) => Genres.FirstOrDefault(p => p.Name == name);
        
        public Genre GetId(int id) => Genres.FirstOrDefault(p => p.Id == id);
       
        public void GetAllGenres(HashSet<int> idGenres)
        {
            Console.WriteLine("\nGenres:");
            foreach (var p in idGenres)
            {
                Console.WriteLine("id: " + p + " - " + GetId(p).Name);
            }
            Console.WriteLine("--OK--");
        }
    }
}