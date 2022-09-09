using Sandbox;
using Sandbox.UI;
using Spacebox;

[Library]
public partial class SpaceboxHud : HudEntity<RootPanel>
{
	public SpaceboxHud()
	{
		if ( !IsClient )
			return;

		//RootPanel.StyleSheet.Add(sandboxStyle);
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
		RootPanel.AddChild<CurrentSpaceboxTool>();
		RootPanel.AddChild<ShipCoreInfo>();
	}
}
