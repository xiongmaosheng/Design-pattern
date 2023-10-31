using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰器模式
{
    public abstract class DecoratorBase : IDecorator
    {
        protected IText target;
        public DecoratorBase(IText target)
        {
            this.target = target;
        }

        public abstract string Content { get; }
    }
}
