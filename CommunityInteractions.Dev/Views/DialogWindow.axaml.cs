using Avalonia.Controls;
using CommunityInteractions.Dev.ViewModels;

namespace CommunityInteractions.Dev.Views;

public partial class DialogWindow : Window
{
	private readonly DialogWindowViewModel _vm;
	
	public DialogWindow()
	{
		InitializeComponent();
		_vm = new();
		_vm.Command.OnClose += Close;
		DataContext = _vm;
	}
}