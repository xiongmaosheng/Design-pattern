using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂模式
{
    public class Namer
    {
        public string frName, lName;


        public string getFrname()
        {
            return frName;
        }

        public string getLname()
        {
            return lName;
        }
    }
}
