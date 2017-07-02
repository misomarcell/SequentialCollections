using System;
using System.Diagnostics;
using System.IO;

namespace SeekAndArchive
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Current folder: " + Directory.GetCurrentDirectory());

            if ( args.Length == 2 )
            {
                Console.WriteLine("Search here: " + args[0]);
                Console.WriteLine("For a file, called: " + args[1]);


                String result = SearchFolder((Directory.GetCurrentDirectory() + "\\" + args[0]), args[1]);
                if ( result != "" )
                {
                    Console.Write("File found: " + result);
                } else
                {
                    Console.Write("File not found.");
                }

            } else
            {
                Console.WriteLine("Correct argument syntax: [search folder] [file name]");
            }

            Console.ReadKey();
            
        }

        private static String SearchFolder(String Folder, String FileName)
        {
            if ( !File.Exists(Folder + "\\" + FileName) )
            {
                String[] directories;
                try
                {
                    directories = Directory.GetDirectories(Folder);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("(" + Folder + ") Error while searching: " + e);
                    return "";
                }

                
                if ( directories.Length <= 0 ) {
                    return "";
                } else
                {
                    foreach (String directory in directories ) {
                        Debug.WriteLine("Directory found: " + directory);
                        SearchFolder(Folder + "\\" + new DirectoryInfo(directory).Name, FileName);
                    }
                }
            } else
            {
                return Folder;
            }

            return "";
        }
    }
}