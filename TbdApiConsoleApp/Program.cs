namespace TbdApiConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            static async Task Main(string[] args)
            {
                do
                {
                    Console.WriteLine("\n\n");

                    Console.WriteLine($"\t\t ============================================================\n");

                    Console.WriteLine($"\t\t Press {"1"} to View All Users in the System");
                    Console.WriteLine($"\t\t Press {"2"} to View A Specific User ");
                    Console.WriteLine($"\t\t Press {"3"} to view Artists Related To A Specific User");
                    Console.WriteLine($"\t\t Press {"4"} to view Genres Related To A Specific User");
                    Console.WriteLine($"\t\t Press {"5"} to view Songs Related To A Specific User");
                    Console.WriteLine($"\t\t Press {"6"} to Add an Artist");
                    Console.WriteLine($"\t\t Press {"7"} to Add a Genre");
                    Console.WriteLine($"\t\t Press {"8"} to Add a Song");
                    Console.WriteLine($"\t\t Press {"9"} to Add a User");

                    Console.WriteLine($"\t\t Press {"0"} to exit\n");

                    Console.WriteLine($"\t\t ============================================================\n");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 0:
                            Environment.Exit(0);
                            break;

                        case 1:
                            await GetUsersNew();
                            EscapeKeyCall();
                            Console.Clear();
                            break;

                        case 2:
                            Console.WriteLine("Enter user Id");
                            int id = Convert.ToInt32(Console.ReadLine());
                            await GetUsernew(id);
                            EscapeKeyCall();
                            Console.Clear();
                            break;

                        case 3:
                            Console.WriteLine("Enter user Id");
                            int idArtists = Convert.ToInt32(Console.ReadLine());
                            await GetArtistsNew(idArtists);
                            EscapeKeyCall();
                            Console.Clear();
                            break;

                        case 4:
                            Console.WriteLine("Enter user Id");
                            int idGenres = Convert.ToInt32(Console.ReadLine());
                            await GetGenresNew(idGenres);
                            EscapeKeyCall();
                            Console.Clear();
                            break;

                        case 5:
                            Console.WriteLine("Enter user Id");
                            int idSongs = Convert.ToInt32(Console.ReadLine());
                            await GetSongsNew(idSongs);
                            Console.WriteLine("\n");
                            EscapeKeyCall();
                            Console.Clear();
                            break;

                        case 6:
                            await AddArtist();
                            EscapeKeyCall();
                            Console.Clear();
                            break;

                        case 7:
                            await AddGenre();
                            EscapeKeyCall();
                            Console.Clear();
                            break;

                        case 8:
                            await AddSongs();
                            EscapeKeyCall();
                            Console.Clear();
                            break;

                        case 9:
                            await AddUser();
                            EscapeKeyCall();
                            Console.Clear();
                            break;

                        default:
                            Console.WriteLine("\n\t\t\t\u001b[31m Wrong Choice. Please try again\t\t\t\u001b[0m");
                            Thread.Sleep(2000);
                            Console.Clear();
                            break;
                    }
                } while (true);


            }
        }
    }
}
