using ProjectManager.Pages;
using ProjectManager.ViewModels;

namespace ProjectManager
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        MainViewModel _viewModel;

        public MainPage(MainViewModel mainViewModel)
        {
            _viewModel = mainViewModel;
            InitializeComponent();
            BindingContext = _viewModel;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(ProjectDetailsPage));
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is ProjectViewModel viewModel)
            {
                Shell.Current.GoToAsync(nameof(ProjectDetailsPage),
                    new Dictionary<string, object>
                    {
                        { "project", viewModel }
                    });
            }
        }
        private void DeleteProject(ProjectViewModel project)
        {
            if (_viewModel.Projects.Contains(project))
            {
                _viewModel.Projects.Remove(project);
            }
        }
        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var project = button?.BindingContext as ProjectViewModel;

            if (project != null)
            {
                DeleteProject(project);
            }
        }
    }

}
