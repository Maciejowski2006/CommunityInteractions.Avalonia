using System.Threading.Tasks;
using CommunityInteractions.Avalonia;
using CommunityInteractions.Dev.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CommunityInteractions.Dev.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
	public readonly Interaction OpenDialogInteraction = new();
	[ObservableProperty] private string _dialogResult = "Empty";
	
	[RelayCommand]
	private async Task OpenDialog()
	{
		OpenDialogInteraction.Window = new DialogWindow();
		
		string res = await OpenDialogInteraction.ShowDialog<string>();
		DialogResult = res;
	}
}