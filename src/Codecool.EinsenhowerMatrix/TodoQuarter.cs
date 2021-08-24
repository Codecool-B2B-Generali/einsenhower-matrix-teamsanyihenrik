using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.EinsenhowerMatrix
{
    /// <summary>
    /// Class that represents quarter for items from different categories
    /// </summary>
    public class TodoQuarter
    {
        /// <summary>
        /// Gets or sets list of items
        /// </summary>
        public List<TodoItem> Items = new List<TodoItem>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoQuarter"/> class.
        /// </summary>
        public TodoQuarter()
        {
        }

        /// <summary>
        /// Add item to list
        /// </summary>
        /// <param name="title">title of item</param>
        /// <param name="deadline">deadline of item</param>
        /// <param name="isImportant">boolean that indicates whenever item is important or not</param>
        public void AddItem(string title, DateTime deadline, bool isImportant)
        {
            Items.Add(new TodoItem(title, deadline, isImportant));
        }

        /// <summary>
        /// Removes item instance under given index
        /// </summary>
        /// <param name="index">index of </param>
        public void RemoveItem(int index)
        {
            Items.RemoveAt(index);
        }

        /// <summary>
        /// Destroys all done item
        /// </summary>
        public void ArchiveItems()
        {
        }

        /// <summary>
        /// Returns human readable representation of quarter
        /// </summary>
        /// <returns>string with all nested items</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < Items.Count; i++)
            {
                str.Append(Items[i].ToString());
                str.Append(Environment.NewLine);
            }

            return str.ToString();
        }

        private void SortToDoItems()
        {
            Items.Sort((x, y) => x.Deadline.CompareTo(y.Deadline));
        }
    }
}