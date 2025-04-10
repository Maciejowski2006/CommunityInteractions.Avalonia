using Avalonia.Controls;
using CommunityInteractions.Dev.ViewModels;

namespace CommunityInteractions.Dev.Views;

public partial class MainWindow : Window
{
	private readonly MainWindowViewModel _vm;
	public MainWindow()
	{
		InitializeComponent();
		_vm = new();
		DataContext = _vm;
		
		_vm.OpenDialogInteraction.Register(this);
	}
}