using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰器模式
{
    internal class BlockAllDecorator:DecoratorBase
    {
        public BlockAllDecorator(IText target) : base(target)
        {
        }

        public override string Content
        {
            get
            {
                return string.Empty;
            }
        }
    }
}
