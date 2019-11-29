using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieBD
{
    public class StorageManager
    {
        //            <movie_name, quantity> 

        public Dictionary<string, int> Storage { get; set; }

        public StorageManager() => Storage = new Dictionary<string, int>();

        public bool Add(string name, int quantity)
        {
            if (Storage.ContainsKey(name))
            {
                Storage[name] += quantity;
                return true;
            }

            Storage.Add(name, quantity);
            Console.WriteLine(name + " added to storage. Current quantity is " + Storage[name]);
            return true;
        }

        public bool Remove(string name, int quantity)
        {
            if (!Storage.ContainsKey(name)) return false;

            if (Storage[name] < quantity)
                return false;

            if (Storage[name] == quantity)
            {
                Storage.Remove(name);
                Console.WriteLine(name + " removed from storage. Current quantity is " + Storage[name]);
                return true;
            }

            Storage[name] -= quantity;
            Console.WriteLine(name + " removed from storage. Current quantity is " + Storage[name]);
            return true;
        }

        public HashSet<string> GetMoviesNames() => new HashSet<string>(Storage.Keys);
        public bool ContainsMovie(string name) => Storage.ContainsKey(name);
        
        public int GetQuantity(string name)
        {
            if (!Storage.ContainsKey(name)) return -1;

            return Storage[name];
        }
    }
}