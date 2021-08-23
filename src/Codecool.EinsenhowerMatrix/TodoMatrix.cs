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
        public Dictionary<string, TodoQuarter> Quarters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoMatrix"/> class.
        /// </summary>
        public TodoMatrix()
        {
        }

        /// <summary>
        /// Creates new item based on given parameters
        /// </summary>
        /// <param name="title">title for new task</param>
        /// <param name="date">deadline for new task</param>
        /// <param name="isImportant">boolean value that indicates whenever task is important or not</param>
        public void AddItem(string title, DateTime date, bool isImportant = false)
        {
        }

        /// <summary>
        /// Deletes all items that are marked as done
        /// </summary>
        public void ArchiveItems()
        {
        }

        /// <summary>
        /// Reads the content from given file, creates and add item to given quarter
        /// </summary>
        /// <param name="filePath">string with path leading to source file</param>
        public void AddItemsFromFile(string filePath)
        {
        }

        /// <summary>
        /// Saves current matrix content to file
        /// </summary>
        /// <param name="filePath">file path under all task will be saved</param>
        public void SaveItemsToFile(string filePath)
        {
        }

        /// <summary>
        /// Returns human readable representation for matrix
        /// </summary>
        /// <returns>string with all quarters and associated items</returns>
        public override string ToString()
        {
            throw new NotImplementedException();
        }

        private DateTime ConvertToDateFrom(string representation)
        {
            throw new NotImplementedException();
        }

        private void CreateQuarters()
        {
        }
    }
}