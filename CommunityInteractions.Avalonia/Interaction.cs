using Avalonia.Controls;

namespace CommunityInteractions.Avalonia;

public class Interaction
{
	public Window? Window { get; set; }
	private Window? Owner { get; set; }

	public Interaction() { }
	public Interaction(Window window)
	{
		Window = window;
	}
	
	public void Register(Window owner)
	{
		Owner = owner;
	}
	
	public void Show()
	{
		if (Window is null)
			throw new NullReferenceException();
		
		Window.Show();
	}

	public async Task ShowDialog()
	{
		if (Window is null || Owner is null)
			throw new NullReferenceException();
		
		await Window.ShowDialog(Owner);
	}

	public async Task<T> ShowDialog<T>()
	{
		if (Window is null || Owner is null)
			throw new NullReferenceException();

		return await Window.ShowDialog<T>(Owner);
	}
}