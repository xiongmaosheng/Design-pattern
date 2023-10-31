using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂模式
{
    public class FirstFirst : Namer
    {
        /// <summary>
        /// 假设:最后一个空格前面的所有部分都属于frName
        /// </summary>
        public FirstFirst(string name) {
            int i = name.Trim().IndexOf(" ");
            if (i > 0)
            {
                frName = name.Substring(0, i).Trim();
                lName = name.Substring(i + 1).Trim();
            }
            else
            {
                frName = name;
                lName = "";
            }
        }
    }
    public class LastFirst : Namer
    {
        public LastFirst(string name)
        {
            int i = name.Trim().IndexOf(",");
            if (i > 0)
            {
                lName = name.Substring(0, i).Trim();
                frName = name.Substring(i + 1).Trim();
            }
            else
            {
                lName = name;
                frName = "";
            }
        }
    }
}
