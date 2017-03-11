using Xunit;

namespace Todo.Domain.Tests
{
    public class TodoTests
    {
        [Fact]
        public void GivenAWrongTitleShouldNotCreateATask()
        {
            var todo = new Todo.Domain.Entities.Todo("");
            Assert.Equal(todo.Notifications.Count, 1);
        }

        [Fact]
        public void GivenACorrectTitleShouldCreateATask()
        {
            var todo = new Todo.Domain.Entities.Todo("Nova Tarefa");
            Assert.Equal(todo.Notifications.Count, 0);
        }
    }
}
