using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstRabbitMQ
{

    public interface interface1
    {
      string GetName { get; set; }
    }

    class Test
    {

    }

    class myBase
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    class Employee : myBase
    {
        public Employee getEmployeeDetails(int id)
        {
            string _createdBy = base.CreatedBy;
            DateTime _createdOn = base.CreatedOn;
            return null;
        }
    }
}
