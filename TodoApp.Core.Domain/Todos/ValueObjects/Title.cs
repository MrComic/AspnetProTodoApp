using Framework.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Framework.Domain.ValueObject;

namespace TodoApp.Core.Domain.Todos.ValueObjects
{
    public class Title : BaseValueObject<Title>
    {
        public string Value { get; private set; }
        public static Title FromString(string value) => new Title(value);
        private Title()
        {

        }
        public Title(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ValidationExceptionBase("مقدار عنوان نمی تواند خالی باشد");
            }
            Value = value;
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(Title otherObject) => Value == otherObject.Value;

        public static implicit operator string(Title actualUrl) => actualUrl.Value;
    }
}
