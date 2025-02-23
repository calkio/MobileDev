using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab4.Model;
using Lab4.Service;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Lab4.ViewModel
{
    public partial class MainPageVM : ObservableObject
    {
        private readonly DatabaseService _dbService;

        [ObservableProperty]
        private string newTaskTitle;

        public ObservableCollection<TodoItem> Items { get; } = new ObservableCollection<TodoItem>();

        public MainPageVM(DatabaseService dbService)
        {
            _dbService = dbService;
            _ = LoadItemsAsync();
        }

        public async Task LoadItemsAsync()
        {
            Items.Clear();
            var items = await _dbService.GetTodoItemsAsync();
            foreach (var item in items)
                Items.Add(item);
        }

        [RelayCommand]
        public async Task AddItemAsync()
        {
            Debug.WriteLine("AddItemAsync вызван");
            if (!string.IsNullOrWhiteSpace(NewTaskTitle))
            {
                var newItem = new TodoItem { Title = NewTaskTitle, IsCompleted = false };
                await _dbService.SaveTodoItemAsync(newItem);
                Items.Add(newItem);
                NewTaskTitle = string.Empty;
            }
        }
    }
}
