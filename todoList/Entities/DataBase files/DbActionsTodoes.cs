using todoList.Entities;

namespace todoList
{
    public static class DbActionsTodoes
    {
        public static void CreateTodo(Todo todo)
        {
            using (TodoContext context = new TodoContext())
            {
                context.Todoes.Add(todo);
                context.SaveChanges();
            }
        }
        public static Todo? ReadTodo(int id)
        {
            using (TodoContext context = new TodoContext())
            {
                foreach (Todo todo in context.Todoes)
                {
                    if (todo.Id == id)
                        return todo;
                }

                return null;
            }
        }
        public static void UpdateTodo(Todo todo)
        {
            using (TodoContext context = new TodoContext())
            {
                context.Todoes.Update(todo);
                context.SaveChanges();
            }
        }
        public static void DeleteTodo(Todo todo)
        {
            using (TodoContext context = new TodoContext())
            {
                context.Todoes.Remove(todo);
                context.SaveChanges();
            }
        }
    }
}
