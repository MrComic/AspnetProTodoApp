using Framework.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Framework.Domain.ValueObject;

namespace TodoApp.Core.Domain.Todos.ValueObjects
{
    public class ValidTo : BaseValueObject<ValidTo>
    {
        public DateTime Value { get; private set; }
        public static DateTime FromString(string value) => new ValidTo(DateTime.Parse(value));
        private ValidTo()
        {

        }
        public ValidTo(DateTime value)
        {
            if (value < DateTime.Now)
            {
                throw new ValidationExceptionBase("تاریخ انجام نباید در گذشته باشد");
            }
            Value = value;
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(ValidTo otherObject) => Value == otherObject.Value;

        public static implicit operator DateTime(ValidTo done) => done.Value;
    }
}
