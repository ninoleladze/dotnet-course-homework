using System;
using System.Collections.Generic;
using System.Text;

namespace _06._29._26_DI.Models._2EX
{
    public class Student : Person
    {
        private string _school;

        public string School
        {
            get { return _school; }
            set { _school = value; }
        }
    }
}
