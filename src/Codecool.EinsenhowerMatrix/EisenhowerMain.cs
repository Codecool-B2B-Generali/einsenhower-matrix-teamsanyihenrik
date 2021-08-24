using System;

namespace Codecool.EinsenhowerMatrix
{
    /// <summary>
    /// Main class for program
    /// </summary>
    public class EisenhowerMain
    {
        /// <summary>
        /// Runs program with basic user UI
        /// </summary>
        public void Run()
        {
            bool exit;
            TodoMatrix matrix = new TodoMatrix();
            do
            {
                exit = matrix.Inputdata();
            }
            while (exit != true);
        }
    }
}
