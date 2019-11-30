using System;
namespace MovieBD
{
    class Program
    {
        public static void Init(StudioManager studioManager, GenreManager genreManager, DirectorManager directorManager, 
            StorageManager storageManager, MovieManager movieManager, CashManager cashManager)
        {
            // add studio
            var pixarId = studioManager.Add("Pixar");
            var disneyId = studioManager.Add("Disney");
            var marvelId = studioManager.Add("MARVEL");
            var universalId = studioManager.Add("Universal");
            var columbiaId = studioManager.Add("Columbia");
            var dreamWorksId = studioManager.Add("DreamWorks");

            // add genre
            var comedyId = genreManager.Add("comedy");
            var cartonId = genreManager.Add("carton");
            var dramaId = genreManager.Add("drama");
            var horrorsId = genreManager.Add("horrors");
            var actionId = genreManager.Add("action");
            var fantasyId = genreManager.Add("fantasy");

            // add directors
            var popovId = directorManager.Add("PopovAA");
            var zverevlId = directorManager.Add("ZverevAB");
            var retrovId = directorManager.Add("PetrovVG");
            var bobrovId = directorManager.Add("BobrovII");
            var pechkinId = directorManager.Add("PechkinDR");
            var andreevId = directorManager.Add("AndreevEI");

            movieManager.Add("Cars", popovId, pixarId, fantasyId);
            movieManager.Add("Hero", bobrovId, universalId, actionId);
            movieManager.Add("ForDead", zverevlId, columbiaId, horrorsId);
            movieManager.Add("ForDead 2", zverevlId, columbiaId, horrorsId);
            movieManager.Add("Cars 2", popovId, pixarId, fantasyId);

            storageManager.Add("Cars", 50);
            storageManager.Add("Hero", 150);
            storageManager.Add("ForDead", 200);
            storageManager.Add("ForDead 2", 100);
            storageManager.Add("Cars 2", 250);

            cashManager.ChangePrice("Cars", 350);
            cashManager.ChangePrice("Hero", 250);
            cashManager.ChangePrice("ForDead", 400);
            cashManager.ChangePrice("ForDead 2", 200);
            cashManager.ChangePrice("Cars 2", 400);

        }
        //----------------------------------------------------------
        public static void Run(StorageManager storageManager)
        {
            Console.WriteLine("\nThe following films are in storage:");
            foreach(var i in storageManager.Storage)
            {
                Console.WriteLine(i.Key + " - " + i.Value);
            }
            Console.WriteLine();
        }
        //----------------------------------------------------------

        public static void Main(string[] args)
        {
            var directorManager = new DirectorManager();
            var studioManager = new StudioManager();
            var genreManager = new GenreManager();
            var movieManager = new MovieManager();
            var storageManager = new StorageManager();
            var cashManager = new CashManager(storageManager, movieManager);

            Init(studioManager, genreManager, directorManager, storageManager, movieManager, cashManager);
            
            Run(storageManager);
            
            while (true)
            {
                Console.WriteLine("Select an action:" +
                                  "\n1) storage" +
                                  "\n2) cash" +
                                  "\n3) show info" +
                                  "\n4) data base edit" +
                                  "\n5) finish\n");
                var val = Console.ReadLine();
                switch (val)
                {
                    //----storage----
                    case "1":
                    {
                        Console.WriteLine("\nSelect options(above the quantity of items):" +
                                          "\n1) add" +
                                          "\n2) subtract" +
                                          "\n3) come back\n");
                        var opt = Console.ReadLine();
                        switch (opt)
                        {
                            //add quantity
                            case "1":
                            {
                                Console.WriteLine("\nEnter Movie name");
                                var name = Console.ReadLine();
                                
                                Console.WriteLine("\nEnter quantity");
                                var q = Console.ReadLine();
                                var quantity = 0;
                                try
                                {
                                    quantity = int.Parse(q);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\n! incorrect number\n");
                                    break;
                                }
                                
                                quantity = int.Parse(q);
                                storageManager.Add(name, quantity);
                                Console.WriteLine("\nOK\n");
                                break;
                            }

                            //subtract
                            case "2":
                            {
                                Console.WriteLine("\nEnter Movie name");
                                var name = Console.ReadLine();
                                
                                Console.WriteLine("\nEnter quantity");
                                var q = Console.ReadLine();
                                
                                var quantity = 0;
                                try
                                {
                                    quantity = int.Parse(q);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\n! incorrect number\n");
                                    break;
                                }
                                
                                quantity = int.Parse(q);
                                if (!storageManager.Remove(name, quantity))
                                {
                                    Console.WriteLine("\n! operation aborted\n");
                                }
                                Console.WriteLine("\nOK\n");
                                break;
                            }

                            //exit
                            case "3":
                            {
                                break;
                            }

                            default:
                            {
                                Console.WriteLine("\n! unknown command, repeat\n");
                                break;
                            }
                        }
                        break;
                    }
                    
                    //cashier
                    case "2":
                    {
                        Console.WriteLine("\nSelect option:" +
                                          "\n1) edit movie price" +
                                          "\n2) add sell " +
                                          "\n3) come back\n");
                        var opt = Console.ReadLine();
                        switch (opt)
                        {
                            // change price
                            case "1":
                            {
                                Console.WriteLine("\nEnter Movie name");
                                var name = Console.ReadLine();
                                
                                Console.WriteLine("\nPlease, enter a new price");
                                var sPrice = Console.ReadLine();

                                var price = 0;
                                try
                                {
                                    price = int.Parse(sPrice);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("! incorrect number");
                                    break;
                                }
                                price = int.Parse(sPrice);

                                Console.WriteLine(cashManager.ChangePrice(name, price) ? "OK" : "ERROR");

                                break;
                            }
                            
                            // add sale
                            case "2":
                            {
                                Console.WriteLine("\nEnter Movie name");
                                var name = Console.ReadLine();
                                
                                Console.WriteLine("\nEnter the number of films sold");
                                var sSale = Console.ReadLine();

                                var sale = 0;
                                try
                                {
                                    sale = int.Parse(sSale);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("! incorrect number");
                                    break;
                                }
                                sale = int.Parse(sSale);

                                Console.WriteLine(cashManager.OfferSale(name, sale) ? "OK" : "ERROR");

                                break;
                            }
                            
                            // exit
                            case "3":
                            {
                                break;
                            }
                            
                            default:
                            {
                                Console.WriteLine("\n! unknown command, repeat\n");
                                break;
                            }
                        }
                        break;
                    }
                    
                    //customer
                    case "3":
                    {
                        Console.WriteLine("\nSelect an action:" +
                                          "\n1 - show all movies" +
                                          "\n2 - show all directors" +
                                          "\n3 - show all studios" +
                                          "\n4 - show all genre" +
                                          "\n5 - show all movies of a certain directors" +
                                          "\n6 - show all movies of a certain studio" +
                                          "\n7 - show all movies of a certain genre" +
                                          "\n8 - buy a movie" +
                                          "\n9 - come back");
                        var opt = Console.ReadLine();

                        switch (opt)
                        {
                            //all movie
                            case "1":
                            {
                                movieManager.ShowMovies(cashManager.GetMovie());
                                Console.WriteLine("\nOK\n");
                                break;
                            }
                            
                            //all directors
                            case "2":
                            {
                                directorManager.GetAllDirectors(cashManager.GetDirector());
                                Console.WriteLine("\nOK\n");
                                break;
                            }
                            
                            //all studio
                            case "3":
                            {
                                studioManager.GetAllStudios(cashManager.GetStudio());
                                Console.WriteLine("\nOK\n");
                                break;
                            }
                            
                            //all genre
                            case "4":
                            {
                                genreManager.GetAllGenres(cashManager.GetGenre());
                                Console.WriteLine("\nOK\n");
                                break;
                            }
                            
                            //movie by directors
                            case "5":
                            {
                                Console.WriteLine("\nEnter director id");
                                var director = Console.ReadLine();
                                int id;
                                try
                                {
                                    id = int.Parse(director);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\n! unknown command, repeat\n");
                                    break;
                                }

                                id = int.Parse(director);
                                movieManager.ShowDirectors(id, cashManager.GetMovie());
                                Console.WriteLine("\nOK\n");
                                break;
                            }
                            
                            //movie by studio
                            case "6":
                            {
                                Console.WriteLine("\nEnter studio id");
                                var studio = Console.ReadLine();
                                int id;
                                try
                                {
                                    id = int.Parse(studio);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\n! unknown command, repeat\n");
                                    break;
                                }

                                id = int.Parse(studio);
                                movieManager.ShowStudios(id, cashManager.GetMovie());
                                Console.WriteLine("\nOK\n");
                                break;
                            }
                            
                            //movie by genre
                            case "7":
                            {
                                Console.WriteLine("\nEnter genre id");
                                var genre = Console.ReadLine();
                                int id;
                                try
                                {
                                    id = int.Parse(genre);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\n! unknown command, repeat\n");
                                    break;
                                }

                                id = int.Parse(genre);
                                movieManager.ShowGenres(id, cashManager.GetMovie());
                                Console.WriteLine("\nOK\n");
                                break;
                            }
                            
                            //buy a movie
                            case "8":
                            {
                                Console.WriteLine("\nEnter the name of the selected movie:");
                                var name = Console.ReadLine();
                                
                                Console.WriteLine("\nEnter quantity:");
                                var q = Console.ReadLine();
                                
                                int quantity;
                                try
                                {
                                    quantity = int.Parse(q);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\n! unknown command, repeat\n");
                                    break;
                                }

                                quantity = int.Parse(q);
                                Console.WriteLine("\nDeposit money:");
                                var m = Console.ReadLine();
                                int money;
                                try
                                {
                                    money = int.Parse(m);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\n! unknown command, repeat\n");
                                    break;
                                }

                                money = int.Parse(m);
                                var balance = cashManager.Sell(name, quantity, money);
                                Console.WriteLine("Balance: " + balance);
                                Console.WriteLine("\nOK\n");
                                break;
                            }
                            
                            //exit
                            case "9":
                            {
                                break;
                            }
                            
                            default:
                            {
                                Console.WriteLine("\n! unknown command, repeat\n");
                                break;
                            }
                        }
                        
                        break;
                    }
                    
                    //data
                    case "4":
                    {
                        Console.WriteLine("\nSelect option:" +
                                          "\n1) add a new movie" +
                                          "\n2) add a new director" +
                                          "\n3) add a new studio" +
                                          "\n4) add a new genre" +
                                          "\n5) come back\n");
                        var opt = Console.ReadLine();

                        switch (opt)
                        {
                            // new movie
                            case "1":
                            {
                                Console.WriteLine("\nEnter the name of the selected movie:");
                                var name = Console.ReadLine();
                                
                                Console.WriteLine("\nEnter the DIRECTOR of your new movie");
                                var dir = Console.ReadLine();
                                var dirId = 0;
                                try
                                {
                                    dirId = int.Parse(dir);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\n! unknown command, repeat\n");
                                    break;
                                }
                                dirId = int.Parse(dir);

                                Console.WriteLine("\nEnter the STUDIO of your new movie");
                                var studio = Console.ReadLine();
                                var studioId = 0;
                                try
                                {
                                    studioId = int.Parse(studio);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\n! unknown command, repeat\n");
                                    break;
                                }
                                studioId = int.Parse(studio);
                                
                                Console.WriteLine("\nEnter the GENRE of your new movie");
                                var genre = Console.ReadLine();
                                var genreId = 0;
                                try
                                {
                                    genreId = int.Parse(genre);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\n! unknown command, repeat\n");
                                    break;
                                }
                                genreId = int.Parse(genre);
                                
                                movieManager.Add(name, dirId, studioId, genreId);
                                Console.WriteLine("\nOK\n");

                                break;
                            }
                            
                            // new director
                            case "2":
                            {
                                Console.WriteLine("\nEnter new DIRECTOR name");
                                var name = Console.ReadLine();
                                directorManager.Add(name);
                                Console.WriteLine("\nOK\n");
                                break;
                            }
                            
                            // new studio
                            case "3":
                            {
                                Console.WriteLine("\nEnter new STUDIO name");
                                var name = Console.ReadLine();
                                studioManager.Add(name);
                                Console.WriteLine("\nOK\n");
                                break;
                            }
                            
                            // new material
                            case "4":
                            {
                                Console.WriteLine("\nEnter new GENRE name");
                                var name = Console.ReadLine();
                                genreManager.Add(name);
                                Console.WriteLine("\nOK\n");
                                break;
                            }
                            
                            // exit
                            case "5":
                            {
                                break;
                            }

                            default:
                            {
                                Console.WriteLine("\n! unknown command, repeat\n");
                                break;
                            }
                        }
                        break;
                    }
                    
                    //exit
                    case "5":
                    {
                        return;
                    }
                    
                    default:
                    {
                        Console.WriteLine("\n! unknown command, repeat\n");
                        break;
                    }
                }
            }
        }
    }
}