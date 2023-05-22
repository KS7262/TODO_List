using todoList.Entities;

namespace todoList
{
    public static class DbActionsUser
    {
        public static void CreateUser(User user)
        {
            using (TodoContext context = new TodoContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
        public static User? ReadUser(int id)
        {
            using (TodoContext context = new TodoContext())
            {
                foreach (User user in context.Users)
                {
                    if (user.Id == id)
                        return user;
                }

                return null;
            }
        }

        public static User? ReadByPassword(string email, string password)
        {
            using (TodoContext context = new TodoContext())
            {
                foreach (User user in context.Users)
                {
                    if (user.Email == email && user.Password == password)
                        return user;
                }

                return null;
            }
        }
        public static void UpdateUser(User user)
        {
            using (TodoContext context = new TodoContext())
            {
                context.Users.Update(user);
                context.SaveChanges();
            }
        }
        public static void Delete(User user)
        {
            using (TodoContext context = new TodoContext())
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }
    }
}
