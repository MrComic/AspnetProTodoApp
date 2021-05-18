using Framework.Core.Domain.Entities;
using Framework.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Domain.Todos.Events;
using TodoApp.Core.Domain.Todos.ValueObjects;
using TodoApp.Framework.Domain.Entities;
using TodoApp.Framework.Domain.Events;
using TodoApp.Framework.Domain.Exceptions;

namespace TodoApp.Core.Domain.Todos.Entities
{
    public class Todo : BaseEntity, IAuditable 
    {
        public Title Title { get; protected set; }

        public Text Text { get; protected set; }

        public Done Done { get;  protected set; }

        public ValidTo ValidTo { get; protected set; }

        private Todo() { 
        
        }

        public Todo(string Title, string Text, DateTime ValidTo)
        {
            HandleEvent(new TodoCreated() { Text = Text, Title = Title, ValidTo = ValidTo });
        }

        public void HasFinished() {
            HandleEvent(new TodoHasFinished());
        }

        public void UpdateText(string text)
        {
            HandleEvent(new TextUpdated() { Text = text });
        }

        public void UpdateTitle(string title)
        {
            HandleEvent(new TitleUpdated() { Title = title });
        }

        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
                case TodoCreated e:
                    {
                        this.Title = new Title(e.Title);
                        this.Text = new Text(e.Text);
                        this.ValidTo = new ValidTo(e.ValidTo);
                    }
                    break;
                case TodoHasFinished e:
                    {
                        this.Done = new Done(true);
                    }
                    break;
                case TextUpdated e:
                    {
                        this.Text = new Text(e.Text);
                    }
                    break;
                case TitleUpdated e:
                    {
                        this.Title = new Title(e.Title);
                    }
                    break;
                default:
                    throw new CustomExceptionsBase("امکان اجرای عملیات درخواستی وجود ندارد");
            }
        }

        protected override void ValidateInvariants()
        {
            var isValid =
              Title != null &&
              Text != null && ValidTo != null;
            if (!isValid)
            {
                throw new ValidationExceptionBase("وضعیت یادآورس وارد شده ناصحیح می باشد");
            }
        }
    }
}
