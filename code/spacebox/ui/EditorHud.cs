using Sandbox;
using Sandbox.UI;

[Library]
public partial class EditorHud : HudEntity<RootPanel>
{
	public EditorHud()
	{
		if ( !IsClient )
			return;

		//RootPanel.StyleSheet.Add(sandboxStyle);
		RootPanel.StyleSheet.Load( "spacebox/ui/EditorHud.scss" );

		RootPanel.AddChild<Quickbar>();
	}
}
