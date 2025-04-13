namespace CommunityInteractions.Avalonia;

public class InteractionHandler
{
	public event Action<object>? OnClose;
	
	public void Close(object? data = null)
	{
		if (OnClose is null)
			throw new NullReferenceException();
		
		OnClose(data!);
	}
}
