using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Bind
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{Name} {LastName}";
        public DateTime EnlistingDate { get; set; }

        public override string ToString()
        {
            return "[STUDENT]";
        }
    }
}
