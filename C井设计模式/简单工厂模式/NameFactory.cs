using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂模式
{
    public class NameFactory
    {
        public NameFactory() { }
        public Namer getName(string name)
        {
            int i = name.IndexOf(',');
            if (i > 0)
            {
                return new LastFirst(name);
            }
            else
            {
                return new FirstFirst(name);
            }
        }

    }
}
