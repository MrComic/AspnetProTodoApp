using Framework.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Framework.Domain.ValueObject;

namespace TodoApp.Core.Domain.Todos.ValueObjects
{
    public class Text : BaseValueObject<Text>
    {
        public string Value { get; private set; }
        public static Text FromString(string value) => new Text(value);
        private Text()
        {

        }
        public Text(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ValidationExceptionBase("مقدار متن نمی تواند خالی باشد");
            }
            Value = value;
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(Text otherObject) => Value == otherObject.Value;

        public static implicit operator string(Text actualUrl) => actualUrl.Value;
    }
}
