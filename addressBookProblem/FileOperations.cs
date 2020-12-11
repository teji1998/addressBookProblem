using CsvHelper;
using Newtonsoft.Json;
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
        /// <summary>
        /// Reading from text file.
        /// </summary>
        /// <param name="Filename">The filename.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Writing into text file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="addressbook">The addressbook.</param>
        public void WriteText(string filename, List<ContactDetails> addressbook)
        {
            string path = "C:\\Users\\PRITHVIL5\\source\\repos\\addressBookProblem\\addressBookProblem\\" +filename;
            StreamWriter writer = new StreamWriter(path);
            string[] firstLine = { "Firstname", "Lastname", "Address", "City", "State", "Zip", "Mobilenumber","EmailId" };
            string lineOne = string.Join(",", firstLine);
            writer.WriteLine(lineOne);
            for (int num = 0; num < addressbook.Count; num++)
            {
                ContactDetails index = addressbook[num];
                string[] secondLine = { index.firstName, index.lastName, index.address, index.city, index.state, index.zip, index.phoneNumber, index.emailId };
                string lineTwo = string.Join(",", secondLine);
                writer.WriteLine(lineTwo);
            }           
            writer.Close();
        }

        /// <summary>
        /// Writes into json file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="person">The person.</param>
        public void WriteToJson(string filename, List<ContactDetails> person)
        {
            string path = "C:\\Users\\PRITHVIL5\\source\\repos\\addressBookProblem\\addressBookProblem\\" + filename;
            string json = JsonConvert.SerializeObject(person.ToArray());
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Reads from json file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public List<ContactDetails> ReadFromJson(string filename)
        {
            string path = "C:\\Users\\PRITHVIL5\\source\\repos\\addressBookProblem\\addressBookProblem\\" + filename;
            string jsonFile = File.ReadAllText(path);
            List<ContactDetails> person = JsonConvert.DeserializeObject<List<ContactDetails>>(jsonFile);
            return person;
        }

        /// <summary>
        /// Shows the files for all the specified extensions.
        /// </summary>
        public void ShowFiles()
        {
            string path = "C:\\Users\\PRITHVIL5\\source\\repos\\addressBookProblem\\addressBookProblem\\";
            string[] fileArray = Directory.GetFiles(path, "*.txt");
            string[] arrayCSV = Directory.GetFiles(path, "*.csv");
            string[] arrayJson = Directory.GetFiles(path, "*.json");
            foreach (string file in fileArray)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
            foreach (string file in arrayCSV)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
            foreach (string file in arrayJson)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }

        /// <summary>
        ///Writing into CSV File.
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
        /// Reading from CSV File
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
}

