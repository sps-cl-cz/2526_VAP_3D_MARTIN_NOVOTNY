using ProjectManager.ViewModels;

namespace ProjectManager.Pages;

[QueryProperty("Project", "project")]

public partial class ProjectDetailsPage : ContentPage
{
	public ProjectViewModel Project
	{
		get => _project;
		set
		{
			_project = value;
			BindingContext = _project;
		}
	}
	private ProjectViewModel _project;

	public ProjectDetailsPage()
	{
		InitializeComponent();
	}
}