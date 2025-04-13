# CommunityInteractions.Avalonia
Simple package providing a streamlined way for showing dialog boxes, inspired by ReactiveUI.

## Introductions
CommunityInteractions.Avalonia is a library simplifying the process of creating new windows and dialog boxes.
Inspired by ReactiveUI allows for easy window creation. Compatible with any MVVM framework.

## Installation
CommunityInteractions.Avalonia is distributed via NuGet package manager. You can find the package [here](https://www.nuget.org/packages/CommunityInteractions.Avalonia/).
<br>
Use this command in the Package Manager console to install CommunityInteractions.Avalonia manually:
```
Install-Package CommunityInteractions.Avalonia
```

## Usage
In your ViewModel create a public readonly property of type `Interaction`. This will be the bridge between your ViewModel and Window.
```csharp
public partial class MainWindowViewModel : ViewModelBase
{
	public readonly Interaction OpenDialogInteraction = new(new DialogWindow());
}
```
You can also set the window later when you need it.
```csharp
public partial class MainWindowViewModel : ViewModelBase
{
    public readonly Interaction OpenDialogInteraction = new();
    
    [RelayCommand]
    private async Task OpenDialog()
    {
        OpenDialogInteraction.Window = new DialogWindow();
    }
}
```
Next, register the owner-window from the Window class.
```csharp
public partial class MainWindow : Window
{
	private readonly MainWindowViewModel _vm = new();
	public MainWindow()
	{
		InitializeComponent();
		DataContext = _vm;
		
		_vm.OpenDialogInteraction.Register(this);
	}
}
```
Now, if you want to show your window, just call the `Show()`/`ShowDialog()` method. You can also retrieve the return data of a dialog by specifying its type.
```csharp
// Opens window
OpenDialogInteraction.Show();

// Opens dialog
await OpenDialogInteraction.ShowDialog();

// Opens dialog and retrieves information provided by the Close method of a dialog window (Close(data))
string res = await OpenDialogInteraction.ShowDialog<string>();
```
If you need to return some data from your dialog, first you need to add a InteractionHandler to your dialog ViewModel. Next just use the Command.Close() function with your data as its argument.
```csharp
public partial class DialogWindowViewModel : ViewModelBase
{
	public readonly InteractionHandler Command = new();
	
	[RelayCommand]
	private void CloseDialog()
	{
		Command.Close("test");
	}
}
```
Now you have to subscribe to your Close command from your window.
```csharp
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
```

## Examples
Examples are provided in the CommunityInteractions.Dev project.