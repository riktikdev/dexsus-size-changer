using System;
using System.IO;

namespace d3xsus_size_changer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "d3xsus-size-changer | github.com/riktikdev/d3xsus-size-changer";

            Console.WriteLine(@"
╔══╗─╔══╗╔══╗╔══╗╔══╗╔╗╔╗╔══╗───╔══╗╔══╗╔═══╗╔═══╗───╔══╗╔╗╔╗╔══╗╔╗─╔╗╔═══╗╔═══╗╔═══╗
║╔╗╚╗╚═╗║╚═╗║║╔═╝║╔═╝║║║║║╔═╝───║╔═╝╚╗╔╝╚═╗─║║╔══╝───║╔═╝║║║║║╔╗║║╚═╝║║╔══╝║╔══╝║╔═╗║
║║╚╗║╔═╝║──║╚╝║──║╚═╗║║║║║╚═╗───║╚═╗─║║──╔╝╔╝║╚══╗───║║──║╚╝║║╚╝║║╔╗─║║║╔═╗║╚══╗║╚═╝║
║║─║║╚═╗║──║╔╗║──╚═╗║║║║║╚═╗║───╚═╗║─║║─╔╝╔╝─║╔══╝───║║──║╔╗║║╔╗║║║╚╗║║║╚╗║║╔══╝║╔╗╔╝
║╚═╝║╔═╝║╔═╝║║╚═╗╔═╝║║╚╝║╔═╝║───╔═╝║╔╝╚╗║─╚═╗║╚══╗───║╚═╗║║║║║║║║║║─║║║╚═╝║║╚══╗║║║║─
╚═══╝╚══╝╚══╝╚══╝╚══╝╚══╝╚══╝───╚══╝╚══╝╚═══╝╚═══╝───╚══╝╚╝╚╝╚╝╚╝╚╝─╚╝╚═══╝╚═══╝╚╝╚╝─
d3xsus-size-changer | github.com/riktikdev/d3xsus-size-changer");

            Console.Write("\n[?] File path: ");
            string filePath = Console.ReadLine();

            Console.Write("[?] File size (in MB): ");
            int fileSize = int.Parse(Console.ReadLine());

            long sizeInBytes = fileSize * 1024 * 1024;
            byte[] data = new byte[sizeInBytes];
            new Random().NextBytes(data);

            string fileDir = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileName(filePath);
            string newFilePath = Path.Combine(fileDir, Path.GetFileNameWithoutExtension(fileName) + "_fake" + Path.GetExtension(fileName));

            File.Copy(filePath, newFilePath);

            using (FileStream stream = new FileStream(newFilePath, FileMode.Append))
            {
                stream.Write(data, 0, data.Length);
            }

            Console.WriteLine("\nFile created successfully!");
            Console.WriteLine($"File saved in the directory of the original file: {fileDir}");
            Console.WriteLine($"File path: {newFilePath}");

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();

            System.Diagnostics.Process.Start("https://github.com/riktikdev/dexsus-size-changer");
        }
    }
}
