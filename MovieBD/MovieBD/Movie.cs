using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBD
{
    public class Movie
    {
        private string _name;
        private int _idGenre;
        private int _idStudio;
        private int _idDirector;
       
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int IdGenre
        {
            get => _idGenre;
            set => _idGenre = value;
        }

        public int IdDirector
        {
            get => _idDirector;
            set => _idDirector = value;
        }

        public int IdStudio
        {
            get => _idStudio;
            set => _idStudio = value;
        }
        

        public Movie(string name, int director, int studio, int genre)
        {
            if (name.Length == 0) throw new ArgumentOutOfRangeException(nameof(name));
            if (director < 0) throw new ArgumentOutOfRangeException(nameof(director));
            if (studio < 0) throw new ArgumentOutOfRangeException(nameof(studio));
            if (genre < 0) throw new ArgumentOutOfRangeException(nameof(genre));

            _name = name;
            _idDirector = director;
            _idStudio = studio;
            _idGenre = genre;
        }
    }
}