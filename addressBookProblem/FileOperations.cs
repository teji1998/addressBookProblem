using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace addressBookProblem
{
    class FileOperations
    {

        public List<ContactDetails> ReadTxt(string Filename)
        {
            string path = "C:\\Users\\PRITHVIL5\\source\\repos\\addressBookProblem\\addressBookProblem\\" + Filename;
            StreamReader reader = new StreamReader(path);
            List<ContactDetails> contact = new List<ContactDetails>();
            string line = null;
            int x = 0;
            while ((line = reader.ReadLine()) != null)
            {
                x = x + 1;
                if (x != 1)
                {
                    string[] value = line.Split(",");
                    contact.Add(new ContactDetails(value[0], value[1], value[2], value[3], value[4], value[5], value[6], value[7]));
                }
            }
            reader.Close();
            return contact;
        }
        public void WriteText(string filename, List<ContactDetails> addressbook)
        {
            string path = "C:\\Users\\PRITHVIL5\\source\\repos\\addressBookProblem\\addressBookProblem\\" +filename;
            StreamWriter writer = new StreamWriter(path);
            string[] firstLine = { "Firstname", "Lastname", "address", "city", "state", "zip", "mobilenumber" };
            string lineOne = string.Join(",", firstLine);
            writer.WriteLine(lineOne);
            for (int num = 0; num < addressbook.Count; num++)
            {
                ContactDetails index = addressbook[num];
                string[] secondLine = { index.firstName, index.lastName, index.city, index.state, index.zip, index.phoneNumber };
                string lineTwo = string.Join(",", secondLine);
                writer.WriteLine(lineTwo);

            }
            
            writer.Close();
        }

        

        
        public void ShowFiles()
        {
            string path = "C:\\Users\\PRITHVIL5\\source\\repos\\addressBookProblem\\addressBookProblem\\";
            string[] fileArray = Directory.GetFiles(path, "*.txt");
            string[] fileArrays = Directory.GetFiles(path, "*.csv");
            foreach (string file in fileArray)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
            foreach (string file in fileArrays)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }

       /* public void WriteDictionaryToText(string filename, Dictionary<string, string> dictionary)
        {
            string path = "C:\\Users\\PRITHVIL5\\source\\repos\\addressBookProblem\\addressBookProblem\\" + filename;
            using (StreamWriter file = new StreamWriter(path))
                foreach (var entry in dictionary)
                    file.WriteLine("{0},{1}", entry.Key, entry.Value);
        }*/

        /// <summary>
        /// Reads from text to dictionary.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
       /* public Dictionary<string, string> ReadFromTextToDictionary(string filename)
        {
            string path = "C:\\Users\\PRITHVIL5\\source\\repos\\addressBookProblem\\addressBookProblem\\" + filename;
            
            var dictionary = File.ReadLines(path).Select(line => line.Split(',')).
                            ToDictionary(split => split[0], split => split[1]);
            return dictionary;
        }*/

        /// <summary>
        /// Writes the CSV.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="list">The list.</param>
        public void writeCsv(string filename, List<ContactDetails> list)
        {
            string path = "C:\\Users\\PRITHVIL5\\source\\repos\\addressBookProblem\\addressBookProblem\\" + filename;
            using (var writer = new StreamWriter(path))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.Configuration.Delimiter = ",";
                csvWriter.Configuration.HasHeaderRecord = true;
                csvWriter.Configuration.AutoMap<ContactDetails>();
                csvWriter.WriteHeader<ContactDetails>();
                csvWriter.NextRecord();
                csvWriter.WriteRecords(list);
                writer.Flush();
                writer.Close();
            }

        }

        /// <summary>
        /// Reads the CSV.
        /// </summary>
        /// <param name="Filename">The filename.</param>
        /// <returns></returns>
        public List<ContactDetails> ReadCsv(string Filename)
        {
            string path = "C:\\Users\\PRITHVIL5\\source\\repos\\addressBookProblem\\addressBookProblem\\" + Filename;
            StreamReader read = new StreamReader(path);
            CsvReader csvReader = new CsvReader(read, CultureInfo.InvariantCulture);
            List<ContactDetails> person = new List<ContactDetails>();
            person = csvReader.GetRecords<ContactDetails>().ToList();
            return person;
        }


    }

    /*/// <summary>
    /// Reads from stream reader.
    /// </summary>
    public static void ReadFromStreamReader()
    {
        string path = @"C:\\Users\\PRITHVIL5\\source\\repos\\addressBookProblem\\addressBookProblem\\sample.txt";
        if (File.Exists(path))
        {
            using (StreamReader sr = File.OpenText(path))
            {
                String fileData = "";
                while ((fileData = sr.ReadLine()) != null)
                    Console.WriteLine((fileData));
            }
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("No file");
        }
    }

    /// <summary>
    /// Writes the using stream writer.
    /// </summary>
    /// <param name="data">The data.</param>
    public static void WriteUsingStreamWriter(List<string> data)
    {
        string path = @"C:\\Users\\PRITHVIL5\\source\\repos\\addressBookProblem\\addressBookProblem\\sample.txt";
        if (File.Exists(path))
        {
            using (StreamWriter streamWriter = File.AppendText(path))
            {
                foreach (string contact in data)
                {
                    streamWriter.WriteLine(contact);
                }
                streamWriter.Close();
            }
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("No file");
        }
    }*/

}

