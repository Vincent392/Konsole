using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;

namespace Konsole_.NET_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            start();

            void start()
            {
                Console.Title = "Konsole";
                try
                {
                    /*NET45*/
                    Console.WriteLine(File.ReadAllText(".\\cfg\\logo.txt"));
                    /* NET5
				     Console.WriteLine(File.ReadAllText(".\\cfg\\NET5\\logo.txt"));
					 * NET4 */
                    //Console.WriteLine(File.ReadAllText(".\\cfg\\NET4\\logo.txt"));
                    Console.WriteLine("Konsole v0.1.0");
                    KonsoleMain();
                }
                catch (Exception e)
                {
                    //Crash crash = new Crash();
                    //crash.Show();
                    ConsoleCrash();
                }

                void KonsoleMain()
                {
                    Console.Write("> ");
                    var input = Console.ReadLine();

                    if (input == "Help")
                    {
                        try
                        {
                            Console.WriteLine(File.ReadAllText(".\\cfg\\help.txt"));
                            KonsoleMain();
                        }
                        catch (Exception e)
                        {
                            //Crash crash = new Crash();
                            //crash.Show();
                            ConsoleCrash();
                        }
                    }
                    else if (input == "Dir")
                    {
                        var files_list = Directory.GetFiles(@"KONSOLE\USER\");
                        var directory_list = Directory.GetDirectories(@"KONSOLE\USER\");

                        Console.WriteLine("Contents of KonsoleDir\n");
                        foreach (var directory in directory_list)
                        {
                            Console.WriteLine(directory);
                        }
                        foreach (var file in files_list)
                        {
                            Console.WriteLine(file);
                        }
                        KonsoleMain();
                    }
                    else if (input == "Update")
                    {
                        UpdateUtil();
                    }
                    else
                    {
                        Console.WriteLine("KERR1: Command does not exist");
                        KonsoleMain();
                    }
                }

                void ConsoleCrash()
                {
                    Console.WriteLine("[> :(]");
                    Console.WriteLine("					");
                    Console.WriteLine("Sorry, Konsole Crashed, it could be due to these reasons:");
                    Console.WriteLine("1. Missing File");
                    Console.WriteLine("2. Corrupt file");
                    Console.WriteLine("3. Broken build");
                    Console.WriteLine("4. Unexpected IO Error");
                    Console.WriteLine("5. Unknown");
                    Console.WriteLine("Press any key to quit");
                    Console.ReadKey();
                }

                void UpdateUtil()
                {
                    Console.Clear();
                    Console.WriteLine("Konsole Will now check for updates");

                    WebClient webClient = new WebClient();

                    try
                    {
                        if (!webClient.DownloadString("https://pastebin.com/xwmD299A").Contains("0.1.0-NET5-DEV"))
                        {
                            /*Console.WriteLine("An Update Is Avalible, Install it?");
							Console.Write("> ");
							var inputup = Console.ReadLine();
							if (inputup == "yes")
							{*/
                            using (var client = new WebClient())
                            {
                                Process.Start("KonsoleNET4Updater.exe");
                                exitapp();
                            }
                            /*}
							else if (inputup == "no")
							{
								Console.Clear();
								start();
							}
							else
							{
								Console.WriteLine("Enter a option");
							}*/
                        }
                    }


                    catch
                    {
                        Console.WriteLine("oh... that's intresting, no updates... Try again later, or check your connection");
                        Thread.Sleep(5000);
                        Console.Clear();
                        Thread.Sleep(1000);
                        start();
                    }
                }
                void exitapp()
                {

                }
            }
        }
    }
}
