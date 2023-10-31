using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰器模式
{
    public class BlodDecorator : DecoratorBase
    {
        public BlodDecorator(IText target) : base(target)
        {
        }

        public override string Content
        {
            get
            {
                return ChangeToBlodFont(target.Content);
            }
        }

        public string ChangeToBlodFont(string content)
        {
            return "<b>" + content + "</b>";
        }
    }
}
