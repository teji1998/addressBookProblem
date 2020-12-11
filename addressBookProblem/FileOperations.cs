using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace addressBookProblem
{
    class FileOperations
    {


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

        public void WriteCity(string filename, List<ContactDetails> addressbook)
        {
            string path = "C:\\Users\\PRITHVIL5\\source\\repos\\addressBookProblem\\addressBookProblem\\" + filename;
            StreamWriter writer = new StreamWriter(path);
            string[] firstLine = { "Firstname", "city", "state" };
            string lineOne = string.Join(",", firstLine);
            writer.WriteLine(lineOne);
            for (int num = 0; num < addressbook.Count; num++)
            {
                ContactDetails index = addressbook[num];
                Console.WriteLine(index.firstName);
                string[] lineTwo = { index.firstName, index.city, index.state };
                string secondLine = string.Join(",", lineTwo);
                writer.WriteLine(secondLine);

            }
            writer.Flush();
            writer.Close();
        }
        /// <summary>
        /// Reads the text.
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
                    contact.Add(new ContactDetails(value[0], value[1], value[2], value[3], value[4], value[5],value[6],value[7]));
                }
            }
            reader.Close();
            return contact;
        }

        public List<ContactDetails> cityTxt(string Filename)
        {
            string path = "C:\\Users\\PRITHVIL5\\source\\repos\\addressBookProblem\\addressBookProblem\\" + Filename;
            StreamReader reader = new StreamReader(path);
            List<ContactDetails> contact = new List<ContactDetails>();
            string line = null;
            int i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                i = i + 1;
                if (i != 1)
                {
                    string[] value = line.Split(",");
                    contact.Add(new ContactDetails(value[0], value[1], value[2]));
                }
            }
            reader.Close();
            return contact;
        }

        
        public void ShowFiles()
        {
            string path = "C:\\Users\\PRITHVIL5\\source\\repos\\addressBookProblem\\addressBookProblem\\";
            string[] fileArray = Directory.GetFiles(path, "*.txt");
            foreach (string file in fileArray)
            {
                Console.WriteLine(file);
            }

        }

    }
}
