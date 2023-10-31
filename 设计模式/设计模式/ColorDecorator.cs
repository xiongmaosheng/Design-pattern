using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰器模式
{
    internal class ColorDecorator : DecoratorBase
    {
        public ColorDecorator(IText target) : base(target)
        {
        }

        public override string Content
        {
            get
            {
                return AddColorTag(target.Content);
            }
        }

        public string AddColorTag(string content)
        {
            return "<color>" + content + "</color>";
        }
    }
}
