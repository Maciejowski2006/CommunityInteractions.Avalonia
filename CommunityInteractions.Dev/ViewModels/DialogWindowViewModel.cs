using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;

namespace CommunityInteractions.Dev.ViewModels;

public partial class DialogWindowViewModel(Window window) : ViewModelBase
{

	[RelayCommand]
	private void CloseDialog()
	{
		window.Close("Test");
	}
}