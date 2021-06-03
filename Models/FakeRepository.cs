using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Models
{
    public class FakeRepository
    {
        private static List<Book> record = new List<Book>();

        public static IEnumerable<Book> GetStudents()
        {
            return record;
        }

        public static void AddNewStudent(Book student)
        {
            record.Add(student);
        }

        
    }


}

