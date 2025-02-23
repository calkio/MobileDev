using Lab4.ViewModel;

namespace Lab4.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageVM viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
