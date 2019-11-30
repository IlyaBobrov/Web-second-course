using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBD
{
    public class MovieManager
    {
        private HashSet<Movie> _movies;

        public HashSet<Movie> Movies
        {
            get => _movies;
            set => _movies = value;
        }

        public MovieManager()
        {
            _movies = new HashSet<Movie>();
        }

        public void Add(string name, int directorId, int studioId, int genreId)
        {
            if (_movies.Any(p => p.Name == name))
            {
                Console.WriteLine("Toy with such name already exists!");
                return;
            }
            Console.WriteLine("OK");
            _movies.Add(new Movie(name, directorId, studioId, genreId));
        }

        public Movie GetName(string name)
        {
            if (_movies.All(p => p.Name != name))
            {
                throw new System.ArgumentOutOfRangeException("! " + name + " - does not exist");
            }

            return _movies.FirstOrDefault(p => p.Name == name);
        }

        public HashSet<int> GetStudio()
        {
            return (HashSet<int>) _movies.Select(p => p.IdStudio);
            //return _movies.Select(p => p.IdStudio).ToHashSet();
        }

        public HashSet<string> GetStudioId(int studioId) =>(HashSet<string>)_movies.Where(t => t.IdStudio== studioId).Select(t => t.Name);
        

        public HashSet<int> GetGenre() => (HashSet<int>)_movies.Select(p => p.IdGenre);
        public HashSet<string> GetGenreId(int genreId) => (HashSet<string>)_movies.Where(p => p.IdGenre == genreId).Select(p => p.Name);


        public HashSet<int> GetDirector() => (HashSet<int>)_movies.Select(p => p.IdDirector);
        public HashSet<string> GetDirectorId(int directorId) => (HashSet<string>)_movies.Where(p => p.IdDirector == directorId).Select(p => p.Name);

        ///???????
        //public HashSet<string> GetDate(string date) => (HashSet<string>)_movies.FirstOrDefault(p => p.Date == date);


        public void ShowMovies(HashSet<string> movies)
        {
            Console.WriteLine("\nMovies:");
            foreach (var p in movies)
            {
                Console.WriteLine("Movie Name: " + p + 
                                "\t | id Director: " + GetName(p).IdDirector + 
                                "\t | id Studio: " + GetName(p).IdStudio +
                                "\t | id Genre: " + GetName(p).IdGenre);
            }
            Console.WriteLine("--OK--");
        }

        public void ShowDirectors(int id, HashSet<string> mov)
        {
            Console.WriteLine("\nMovies Directors:");
            foreach (var p in mov.Where(p => GetName(p).IdDirector == id))
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("--OK--");
        }

        public void ShowStudios(int id, HashSet<string> mov)
        {
            Console.WriteLine("\nMovies Studios:");
            foreach (var p in mov.Where(p => GetName(p).IdStudio== id))
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("--OK--");
        }

        public void ShowGenres(int id, HashSet<string> mov)
        {
            Console.WriteLine("\nMovies Genres:");
            foreach (var p in mov.Where(p => GetName(p).IdGenre== id))
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("--OK--");
        }
    }
}
