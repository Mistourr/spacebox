using Sandbox;
using Sandbox.UI;

[Library]
public partial class SpaceboxHud : HudEntity<RootPanel>
{
	StyleSheet sandboxStyle = StyleSheet.FromFile( "ui/SandboxHud.scss" );
	public SpaceboxHud()
	{
		if ( !IsClient )
			return;

		//RootPanel.StyleSheet.Add(sandboxStyle);
		SwitchToSandboxHud();
	}
	public void ClearHud()
	{
		RootPanel.DeleteChildren();
	}
	public void BuildEditorHud()
	{
		ClearHud();
	}
	public void BuildSandboxHud()
	{
		ClearHud();
		RootPanel.StyleSheet.Load( "spacebox/ui/SpaceboxHud.scss" );

		RootPanel.AddChild<ChatBox>();
		RootPanel.AddChild<VoiceList>();
		RootPanel.AddChild<VoiceSpeaker>();
		RootPanel.AddChild<KillFeed>();
		RootPanel.AddChild<Scoreboard<ScoreboardEntry>>();
		RootPanel.AddChild<Health>();
		RootPanel.AddChild<InventoryBar>();
		RootPanel.AddChild<CurrentTool>();
		RootPanel.AddChild<SpawnMenu>();
		RootPanel.AddChild<Crosshair>();
	}
	[ClientRpc]
	public void SwitchToSandboxHud()
	{
		BuildSandboxHud();
	}
	[ClientRpc]
	public void SwitchToEditorHud()
	{
		BuildEditorHud();
	}
}
