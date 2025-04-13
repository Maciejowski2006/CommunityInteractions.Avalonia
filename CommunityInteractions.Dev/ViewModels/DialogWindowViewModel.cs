using System;
using Avalonia.Controls;
using CommunityInteractions.Avalonia;
using CommunityToolkit.Mvvm.Input;

namespace CommunityInteractions.Dev.ViewModels;

public partial class DialogWindowViewModel : ViewModelBase
{
	private Func<string> _return;

	public readonly InteractionHandler Command = new();
	
	[RelayCommand]
	private void CloseDialog()
	{
		Command.Close("test");

	}
}