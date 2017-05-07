using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cstructor.Database;

namespace cstructor.Repository
{
  public class DatabaseAccessor
    {
        private static readonly cstructorEntities entities;

        static DatabaseAccessor()
        {
            entities = new cstructorEntities();
            entities.Database.Connection.Open();
        }

        public static cstructorEntities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
