using FluentValidator;

namespace Todo.Domain.Commands
{
    public class RegisterTodoCommand : Notifiable, ICommand
    {
        public RegisterTodoCommand()
        {
        }

        public void Validate()
        {
            new FluentValidator.ValidationContract<RegisterTodoCommand>(this)
                .IsRequired(x => x.Title, "Informe a tarefa")
                .HasMaxLength(x => x.Title, 60, "A tarefa deve conter no máximo 60 caracteres")
                .HasMinLength(x => x.Title, 3, "Tarefa inválida");
        }
        public string Title { get; set; }
    }
}
