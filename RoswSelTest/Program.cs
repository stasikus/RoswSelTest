using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoswSelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //InitializeComponent();
            Driver.Initialize();
            DriverWait.Initialize(5);

            //Login.GoTo("http://roswar.ru");
        }
    }
}
