﻿using System;
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
            String fileFound = "";
            Debug.WriteLine("FILE: " + FileName);
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
                    Debug.WriteLine("No more directories");
                    return "";
                } else
                {
                    foreach (String directory in directories ) {
                        Debug.WriteLine("Directory found: " + directory);
                        fileFound = SearchFolder(Folder + "\\" + new DirectoryInfo(directory).Name, FileName);

                        if (fileFound != "")
                        {
                            return fileFound;
                        }
                    }
                }
            } 
                return Folder;
        }
    }
}