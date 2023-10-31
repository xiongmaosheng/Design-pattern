using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰器模式
{
    public class TextObject:IText
    {
        public string Content {
            get
            {
                return "hello";
            }
        }
    }
}
