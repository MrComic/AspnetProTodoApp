using Framework.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Framework.Domain.ValueObject;

namespace TodoApp.Core.Domain.Todos.ValueObjects
{
    public class Done : BaseValueObject<Done>
    {
        public bool? Value { get; private set; }
        public static Done FromString(string value) => new Done(bool.Parse(value));
        private Done()
        {

        }
        public Done(bool? value)
        {
            Value = value;
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(Done otherObject) => Value == otherObject.Value;

        public static implicit operator bool?(Done done) => done.Value;
    }
}
