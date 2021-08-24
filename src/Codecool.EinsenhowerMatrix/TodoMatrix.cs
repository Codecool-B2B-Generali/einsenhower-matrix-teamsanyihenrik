using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Codecool.EinsenhowerMatrix
{
    /// <summary>
    /// Top level class for Matrix
    /// </summary>
    public class TodoMatrix
    {
        /// <summary>
        /// Gets or sets dictionary with quarters
        /// </summary>
        public Dictionary<string, TodoQuarter> Dict = new Dictionary<string, TodoQuarter>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoMatrix"/> class.
        /// </summary>
        public TodoMatrix()
        {
            CreateQuarters();
        }

        /// <summary>
        /// user input
        /// </summary>
        public bool Inputdata()
        {
            string filepath = "c:\\todoitems\\items.csv";
            string input;
            Console.WriteLine("0 = quit");
            Console.WriteLine("1 = enter new task");
            Console.WriteLine("2 = delete all finished tasks");
            Console.WriteLine("3 = load tasks from file");
            Console.WriteLine("4 = save tasks to file");
            Console.WriteLine("5 = show all tasks");
            Console.WriteLine("6 = finish a task");
            Console.WriteLine("7 = show selected quarter's tasks");
            input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    return true;
                    break;

                case "1":
                    Console.WriteLine("Item title?");
                    input = Console.ReadLine();
                    string title = input;

                    Console.WriteLine("Item date?");
                    input = Console.ReadLine();
                    DateTime dt;
                    while (!DateTime.TryParseExact(input, "yyyy.MM.dd", null, System.Globalization.DateTimeStyles.None, out dt))
                    {
                        Console.WriteLine("Invalid date, please retry");
                        input = Console.ReadLine();
                    }

                    Console.WriteLine("Is important y/n?");
                    input = Console.ReadLine();
                    Boolean important;
                    while ((input != "y") && (input != "n"))
                    {
                        Console.WriteLine("Invalid answer, please retry");
                        input = Console.ReadLine();
                    }

                    if (input == "y") important = true;
                    else important = false;

                    AddItem(title, dt, important);
                    return false;
                    break;

                case "2":
                    ArchiveItems();
                    return false;
                    break;

                case "3":
                    Console.WriteLine("Read from path: " + filepath);
                    AddItemsFromFile(filepath);
                    return false;
                    break;

                case "4":
                    Console.WriteLine("Save to path: " + filepath);
                    SaveItemsToFile(filepath);
                    return false;
                    break;

                case "5":
                    Console.WriteLine(ToString());
                    return false;
                    break;

                case "6":
                    Console.WriteLine("Item title?");
                    input = Console.ReadLine();
                    FinishItem(input);
                    return false;
                    break;

                case "7":
                    Console.WriteLine("Selected quarter?");
                    Console.WriteLine("1 = Urgent & Important");
                    Console.WriteLine("2 = Urgent & Not important");
                    Console.WriteLine("3 = Not urgent & Important");
                    Console.WriteLine("4 = Not urgent & Not important");
                    string input2 = Console.ReadLine();
                    while ((input2 != "1") && (input2 != "2") && (input2 != "3") && (input2 != "4"))
                    {
                        Console.WriteLine("Invalid answer, please retry");
                        input2 = Console.ReadLine();
                    }

                    switch (input2)
                    {
                        case "1":
                            input2 = "Urgent & Important";
                            break;
                        case "2":
                            input2 = "Urgent & Not important";
                            break;
                        case "3":
                            input2 = "Not urgent & Important";
                            break;
                        case "5":
                            input2 = "Not urgent & Not important";
                            break;
                    }

                    ShowSelected(input2);
                    return false;
                    break;
            }

            return false;
        }

        /// <summary>
        /// showsel
        /// </summary>
        public void ShowSelected(string input)
        {
            foreach (KeyValuePair<string, TodoQuarter> kvp in Dict)
            {
                if (kvp.Key.Equals(input))
                {
                    Console.WriteLine(kvp.Value.ToString());
                }
            }
        }

        /// <summary>
        /// finish item
        /// </summary>
        /// <param name="title">title</param>
        public void FinishItem(string title)
        {
            foreach (KeyValuePair<string, TodoQuarter> kvp in Dict)
            {
                var item = kvp.Value.Items.Find(x => x.Title == title);
                if (item != null) item.Mark();
            }
        }

        /// <summary>
        /// Creates new item based on given parameters
        /// </summary>
        /// <param name="title">title for new task</param>
        /// <param name="date">deadline for new task</param>
        /// <param name="isImportant">boolean value that indicates whenever task is important or not</param>
        public void AddItem(string title, DateTime date, bool isImportant)
        {
            TimeSpan elapsed = date.Subtract(DateTime.Now);
            int days = elapsed.Days;

            if ((isImportant == true) && (days <= 3))
            {
                Dict["Urgent & Important"].AddItem(title, date, isImportant);
            }

            if ((isImportant == true) && (days > 3))
            {
                Dict["Not urgent & Important"].AddItem(title, date, isImportant);
            }

            if ((isImportant == false) && (days >= 3))
            {
                Dict["Not urgent & Not important"].AddItem(title, date, isImportant);
            }

            if ((isImportant == false) && (days < 3))
            {
                Dict["Urgent & Not important"].AddItem(title, date, isImportant);
            }
        }

        /// <summary>
        /// Deletes all items that are marked as done
        /// </summary>
        public void ArchiveItems()
        {
            foreach (KeyValuePair<string, TodoQuarter> kvp in Dict)
            {
                var item = kvp.Value.Items.Find(x => x.IsDone == true);
                if (item != null) kvp.Value.Items.Remove(item);
            }
        }

        /// <summary>
        /// Reads the content from given file, creates and add item to given quarter
        /// </summary>
        /// <param name="filePath">string with path leading to source file</param>
        public void AddItemsFromFile(string filePath)
        {
            Dict.Clear();
            CreateQuarters();
            StreamReader readFile = new StreamReader(filePath);
            string line;
            string[] row;
            while ((line = readFile.ReadLine()) != null)
            {
                row = line.Split(';');
                DateTime dt;
                DateTime.TryParseExact(row[1], "yyyy.MM.dd h:mm:ss", null, System.Globalization.DateTimeStyles.None, out dt);
                bool bo = bool.Parse(row[2]);
                AddItem(row[0], dt, bo);
            }

            readFile.Close();
        }

            /// <summary>
            /// Saves current matrix content to file
            /// </summary>
            /// <param name="filePath">file path under all task will be saved</param>
        public void SaveItemsToFile(string filePath)
        {
            StringBuilder csv = new StringBuilder();
            foreach (KeyValuePair<string, TodoQuarter> kvp in Dict)
            {
                foreach (TodoItem item in kvp.Value.Items)
                {
                    string s1 = item.Title;
                    string s2 = item.Deadline.ToString();
                    string s3 = item.IsImportant.ToString();
                    string line = string.Format("{0};{1};{2}", s1, s2, s3);
                    csv.AppendLine(line);
                }
            }

            File.WriteAllText(filePath, csv.ToString());
        }

        /// <summary>
        /// Returns human readable representation for matrix
        /// </summary>
        /// <returns>string with all quarters and associated items</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, TodoQuarter> kvp in Dict)
            {
                sb.Append(kvp.Key + " : " + kvp.Value.ToString());
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        private DateTime ConvertToDateFrom(string representation)
        {
            throw new NotImplementedException();
        }

        private void CreateQuarters()
        {
            Dict.Add("Urgent & Important", new TodoQuarter());

            Dict.Add("Not urgent & Important", new TodoQuarter());

            Dict.Add("Urgent & Not important", new TodoQuarter());

            Dict.Add("Not urgent & Not important", new TodoQuarter());
        }
    }
}