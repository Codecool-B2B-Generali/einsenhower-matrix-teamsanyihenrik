using System;

namespace Codecool.EinsenhowerMatrix
{
    /// <summary>
    /// Base class that represents task
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// Gets or sets Task's title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Task's deadline
        /// </summary>
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether task is complete or not
        /// </summary>
        public bool IsDone { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether task is important or not
        /// </summary>
        public bool IsImportant { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoItem"/> class.
        /// </summary>
        /// <param name="title">string representation for title</param>
        /// <param name="deadline">deadline for title</param>
        public TodoItem(string title, DateTime deadline)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoItem"/> class.
        /// </summary>
        /// <param name="title">string representation for title</param>
        /// <param name="deadline">deadline for title</param>
        /// <param name="isImportant">value indicating whether task is important or not</param>
        public TodoItem(string title, DateTime deadline, bool isImportant)
            : this(title, deadline)
        {
        }

        /// <summary>
        /// Marks item as done
        /// </summary>
        public void Mark()
        {
        }

        /// <summary>
        /// Marks item as undone
        /// </summary>
        public void UnMark()
        {
        }

        /// <summary>
        /// Returns a human readable representation for task
        /// </summary>
        /// <returns>string containing instance values</returns>
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}