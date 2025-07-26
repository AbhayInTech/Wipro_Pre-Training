using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_1
{
    internal interface IEmployee
    {
        // creating the interface for Employee to be implement into the Employee class
        int setID();
        string setDepartment();
        double setSalary();
        string setAddress();
        string setPhoneNumber();
        string setEmail();
    }
}
