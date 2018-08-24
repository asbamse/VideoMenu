using System;
using System.Collections.Generic;

namespace VideoMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoModification vmod = new VideoModification();
            GenreModification gmod = new GenreModification();
            Menu main = new Menu("Video Menu");
            Menu readVideo = new Menu("Video Menu -> read");
            Menu menuGenre = new Menu("Genre Menu");
            Menu readGenre = new Menu("Genre Menu -> read");

            #region Main
            main.SetMenu(
                new MenuItem[] {
                    new MenuItem("Create", () =>
                    {
                        string name = ConsoleUtils.ReadNotEmpty("Input video name: ");
                        Genre genre = null;
                        List<Genre> genres = gmod.getGenres();
                        MenuItem[] genreItems = new MenuItem[genres.Count];
                        Menu chooseGenre = new Menu("Video Menu -> choose genre");

                        for (int i = 0; i < genres.Count; i++)
                        {
                            int ci = i;
                            genreItems[ci] = new MenuItem(genres[ci].Name, () => { genre = genres[ci]; chooseGenre.Exit(); });
			            }

                        if(genreItems.Length > 0)
                        {
                            chooseGenre.SetMenu(genreItems);
                            chooseGenre.Show();

                            if(vmod.addVideo(name, genre))
                            {
                                Console.WriteLine("The video succesfully added.");
                            }
                            else
                            {
                                Console.WriteLine("The video was not added.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No genres found! Create the genre before creating the video.");
                        }
                    }),
                    new MenuItem("Read", () =>
                    {
                        Console.Clear();
                        readVideo.Show();
                    }),
                    new MenuItem("Update", () =>
                    {
                        int id = ConsoleUtils.ReadInt("Input video id: ");
                        string name = ConsoleUtils.ReadNotEmpty("Input video name: ");
                        Genre genre = null;
                        List<Genre> genres = gmod.getGenres();
                        MenuItem[] genreItems = new MenuItem[genres.Count];
                        Menu chooseGenre = new Menu("Video Menu -> choose genre");

                        for (int i = 0; i < genres.Count; i++)
                        {
                            int ci = i;
                            genreItems[ci] = new MenuItem(genres[ci].Name, () => { genre = genres[ci]; chooseGenre.Exit(); });
                        }

                        if(genreItems.Length > 0)
                        {
                            chooseGenre.SetMenu(genreItems);
                            chooseGenre.Show();

                            if(vmod.updateVideo(id, name, genre))
                            {
                                Console.WriteLine("Video successfully update.");
                            }
                            else
                            {
                                Console.WriteLine("Video not found nor updated.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No genres found! Create the genre before creating the video.");
                        }
                    }),
                    new MenuItem("Delete", () =>
                    {
                        if(vmod.deleteVideo(ConsoleUtils.ReadInt("Input video id: ")))
                        {
                            Console.WriteLine("Video successfully deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Video not found nor deleted.");
                        }
                    }),
                    new MenuItem("Genre", () =>
                    {
                        Console.Clear();
                        menuGenre.Show();
                    }),
                    new MenuItem("Clear", () =>
                    {
                        Console.Clear();
                        main.Show();
                    }),
                    new MenuItem("Exit", () =>
                    {
                        System.Environment.Exit(0);
                    })
                });
            #endregion

            #region ReadVideo
            readVideo.SetMenu(
                new MenuItem[]
                {
                    new MenuItem("Read All", () =>
                    {
                        List<Video> videos = vmod.getVideos();

                        if(videos.Count > 0)
                        {
                            foreach (Video video in videos)
                            {
                                Console.WriteLine("ID: {0}, Name: {1}, Genre: {2}", video.Id, video.Name, video.Genre.Name);
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no videos stored.");
                        }
                    }),
                    new MenuItem("Read by ID", () =>
                    {
                        int id = ConsoleUtils.ReadInt("Input ID: ");

                        List<Video> videos = vmod.getVideos();

                        if(videos.Count > 0)
                        {
                            int count = 0;
                            foreach (Video video in videos)
                            {
                                if(video.Id == id)
                                {
                                Console.WriteLine("ID: {0}, Name: {1}, Genre: {2}", video.Id, video.Name, video.Genre.Name);
                                    count++;
                                }
                            }
                            if(count == 0)
                            {
                                Console.WriteLine("There are no videos stored with the ID {0}.", id);
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no videos stored with the ID {0}.", id);
                        }
                    }),
                    new MenuItem("Search by name", () =>
                    {
                        Console.Write("Input search: ");

                        List<Video> videos = vmod.searchVideo(Console.ReadLine());

                        if(videos.Count > 0)
                        {
                            foreach (Video video in videos)
                            {
                                Console.WriteLine("ID: {0}, Name: {1}, Genre: {2}", video.Id, video.Name, video.Genre.Name);
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no videos found.");
                        }
                    }),
                    new MenuItem("Clear", () =>
                    {
                        Console.Clear();
                        readVideo.Show();
                    }),
                    new MenuItem("Back", () =>
                    {
                        Console.Clear();
                        main.Show();
                    }),
                    new MenuItem("Exit", () =>
                    {
                        System.Environment.Exit(0);
                    })
                });
            #endregion

            #region Genre
            menuGenre.SetMenu(
                new MenuItem[] 
                {
                    new MenuItem("Create", () =>
                    {
                        if(gmod.addGenre(ConsoleUtils.ReadNotEmpty("Input genre name: ")))
                        {
                            Console.WriteLine("The genre succesfully added.");
                        }
                        else
                        {
                            Console.WriteLine("The genre was not added.");
                        }
                    }),
                    new MenuItem("Read", () =>
                    {
                        Console.Clear();
                        readGenre.Show();
                    }),
                    new MenuItem("Update", () =>
                    {
                        int id = ConsoleUtils.ReadInt("Input genre id: ");

                        if(gmod.updateGenre(id, ConsoleUtils.ReadNotEmpty("Input genre name: ")))
                        {
                            Console.WriteLine("Genre successfully update.");
                        }
                        else
                        {
                            Console.WriteLine("Genre not found nor updated.");
                        }
                    }),
                    new MenuItem("Delete", () =>
                    {
                        if(gmod.deleteGenre(ConsoleUtils.ReadInt("Input genre id: ")))
                        {
                            Console.WriteLine("Genre successfully deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Genre not found nor deleted.");
                        }
                    }),
                    new MenuItem("Clear", () =>
                    {
                        Console.Clear();
                        menuGenre.Show();
                    }),
                    new MenuItem("Back", () =>
                    {
                        Console.Clear();
                        main.Show();
                    }),
                    new MenuItem("Exit", () =>
                    {
                        System.Environment.Exit(0);
                    })
                });
            #endregion

            #region ReadGenre
            readGenre.SetMenu(
                new MenuItem[]
                {
                    new MenuItem("Read All", () =>
                    {
                        List<Genre> genres = gmod.getGenres();

                        if(genres.Count > 0)
                        {
                            foreach (Genre genre in genres)
                            {
                                Console.WriteLine("ID: {0}, Name: {1}", genre.Id, genre.Name);
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no genres stored.");
                        }
                    }),
                    new MenuItem("Read by ID", () =>
                    {
                        int id = ConsoleUtils.ReadInt("Input ID: ");

                        List<Genre> genres = gmod.getGenres();

                        if(genres.Count > 0)
                        {
                            int count = 0;
                            foreach (Genre genre in genres)
                            {
                                if(genre.Id == id)
                                {
                                    Console.WriteLine("ID: {0}, Name: {1}", genre.Id, genre.Name);
                                    count++;
                                }
                            }
                            if(count == 0)
                            {
                                Console.WriteLine("There are no genres stored with the ID {0}.", id);
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no genres stored with the ID {0}.", id);
                        }
                    }),
                    new MenuItem("Search by name", () =>
                    {
                        Console.Write("Input search: ");

                        List<Genre> genres = gmod.searchGenre(Console.ReadLine());

                        if(genres.Count > 0)
                        {
                            foreach (Genre genre in genres)
                            {
                                Console.WriteLine("ID: {0}, Name: {1}", genre.Id, genre.Name);
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no genres found.");
                        }
                    }),
                    new MenuItem("Clear", () =>
                    {
                        Console.Clear();
                        readGenre.Show();
                    }),
                    new MenuItem("Back", () =>
                    {
                        Console.Clear();
                        menuGenre.Show();
                    }),
                    new MenuItem("Exit", () =>
                    {
                        System.Environment.Exit(0);
                    })
                });
            #endregion

            main.Show();
        }
    }
}
