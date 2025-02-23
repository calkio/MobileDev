using Lab4.Model;
using SQLite;

namespace Lab4.Service
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TodoItem>().Wait();
        }

        public Task<List<TodoItem>> GetTodoItemsAsync()
        {
            return _database.Table<TodoItem>().ToListAsync();
        }

        public Task<int> SaveTodoItemAsync(TodoItem item)
        {
            if (item.ID != 0)
                return _database.UpdateAsync(item);
            else
                return _database.InsertAsync(item);
        }

        public Task<int> DeleteTodoItemAsync(TodoItem item)
        {
            return _database.DeleteAsync(item);
        }
    }
}
