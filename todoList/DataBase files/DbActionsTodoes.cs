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
        public static Todo? ReadTodoByTitle(string title)
        {
            using (TodoContext context = new TodoContext())
            {
                foreach (Todo todo in context.Todoes)
                {
                    if (todo.Title == title)
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

        public static List<string> GetTodoes(User user)
        {
            List<string> titles = new List<string>();
            using (TodoContext context = new TodoContext())
            {
                foreach (var item in context.Todoes.Where(u => u.User == user))
                {
                    titles.Add(item.Title);
                }
            }
            return titles;
        }
    }
}
