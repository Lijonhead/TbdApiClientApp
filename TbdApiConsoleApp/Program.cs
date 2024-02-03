﻿using Newtonsoft.Json;
using System.Text;

namespace TbdApiConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
        public static async Task AddSongs()
        {
            Console.WriteLine("Enter User Id");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("Invalid userId.");
                return;
            }
            Console.WriteLine("Enter Artist Id");

            if (!int.TryParse(Console.ReadLine(), out int artistId))
            {
                Console.WriteLine("Invalid Artist Id.");
                return;
            }

            Console.WriteLine("Enter GenreId");

            if (!int.TryParse(Console.ReadLine(), out int genreId))
            {
                Console.WriteLine("Invalid Genre Id.");
                return;
            }

            Console.WriteLine("Enter Song Title");
            string songtitle = Console.ReadLine();

            using (HttpClient client = new HttpClient())
            {



                string apiUrl = $"https://localhost:7224/AddSongs/{userId}/{artistId}/{genreId}";

                var Song = new List<object>
        {
            new {SongTitle= songtitle }
        };
                string songs = JsonConvert.SerializeObject(Song);
                var content = new StringContent(songs, Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        Console.WriteLine($"Result from API:\n{result}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }

        public static async Task GetUsernew(int userid)
        {

            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("Calling WebAPI....");


                string apiUrl = $"https://localhost:7224/GetUser/{userid}";

                try
                {
                    var response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Result from API:\n");


                        Console.WriteLine(JsonConvert.DeserializeObject($"{result}"));
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }


            }
        }


        public static async Task GetArtistsNew(int userid)
        {

            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("Calling WebAPI....");


                string apiUrl = $"https://localhost:7224/GetArtists/{userid}";

                try
                {
                    var response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Result from API:\n");

                        var ArtistsList = JsonConvert.DeserializeObject<List<ViewModels.ArtistsViewModel>>(result);


                        foreach (var artist in ArtistsList)
                        {
                            Console.WriteLine($"Artist ID: {artist.artistId}, Artist Name: {artist.artistName}, Artist Description: {artist.artistDescription}");
                        }



                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }


            }
        }
    }
}
