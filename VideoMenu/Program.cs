using System;
using System.Collections.Generic;

namespace VideoMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoModification vmod = new VideoModification();
            ConsoleUtils cu = new ConsoleUtils();
            Menu main = new Menu();
            main.setMenu(
                new MenuItem[] {
                    new MenuItem("Create", () =>
                        {
                            Console.Write("Input video name: ");

                            if(vmod.addVideo(Console.ReadLine()))
                            {
                                Console.WriteLine("The video succesfully added.");
                            }
                            else
                            {
                                Console.WriteLine("The video was not added.");
                            }
                        }),
                    new MenuItem("Read", () =>
                        {
                            List<Video> videos = vmod.getVideos();

                            if(videos.Count > 0)
                            {
                                foreach (Video video in videos)
                                {
                                    Console.WriteLine("ID: {0}, Name: {1}", video.Id, video.Name);
                                }
                            }
                            else
                            {
                                Console.WriteLine("There are no videos stored.");
                            }
                        }),
                    new MenuItem("Update", () =>
                        {
                            Console.Write("Input video id: ");
                            int id = cu.ReadInt();
                            Console.Write("Input video name: ");

                            if(vmod.updateVideo(id, Console.ReadLine()))
                            {
                                Console.WriteLine("Video successfully update.");
                            }
                            else
                            {
                                Console.WriteLine("Video not found nor updated.");
                            }
                        }),
                    new MenuItem("Delete", () =>
                        {
                            Console.Write("Input video id: ");

                            if(vmod.deleteVideo(cu.ReadInt()))
                            {
                                Console.WriteLine("Video successfully deleted.");
                            }
                            else
                            {
                                Console.WriteLine("Video not found nor deleted.");
                            }
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
            main.Show();
        }
    }
}
