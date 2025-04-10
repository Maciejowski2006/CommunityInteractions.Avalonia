# CommunityInteractions.Avalonia
Simple package providing a streamlined way for showing dialog boxes, inspired by ReactiveUI.

## Introductions
CommunityInteractions.Avalonia is a library simplifying the process of creating new windows and dialog boxes.
Inspired by ReactiveUI allows for easy window creation. Compatible with any MVVM framework.

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

## Examples
Examples are provided in the CommunityInteractions.Dev project.