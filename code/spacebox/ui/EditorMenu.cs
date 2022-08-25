using Sandbox;
using Sandbox.Tools;
using Sandbox.UI;
using Sandbox.UI.Construct;


[Library]
public partial class EditorMenu : Panel
{
	public static EditorMenu Instance;
	bool menuopen = false;

	/*
	public void SpawnMenu()
	{
		Instance = this;

		StyleSheet.Load( "/ui/EditorMenu.scss" );

		var left = Add.Panel( "left" );
		{
			var tabs = left.AddChild<ButtonGroup>();
			tabs.AddClass( "tabs" );

			var body = left.Add.Panel( "body" );

			{
				var props = body.AddChild<SpawnList>();
				tabs.SelectedButton = tabs.AddButtonActive( "Props", ( b ) => props.SetClass( "active", b ) );

				var ents = body.AddChild<EntityList>();
				tabs.AddButtonActive( "Entities", ( b ) => ents.SetClass( "active", b ) );

				var models = body.AddChild<CloudModelList>();
				tabs.AddButtonActive( "s&works", ( b ) => models.SetClass( "active", b ) );
			}
		}

		var right = Add.Panel( "right" );
		{
			var tabs = right.Add.Panel( "tabs" );
			{
				tabs.Add.Button( "Tools" ).AddClass( "active" );
				tabs.Add.Button( "Utility" );
			}
			var body = right.Add.Panel( "body" );
			{
				toollist = body.Add.Panel( "toollist" );
				{
					RebuildToolList();
				}
				body.Add.Panel( "inspector" );
			}
		}

	}
	*/
	public EditorMenu()
	{
		Instance = this;

		StyleSheet.Load( "/ui/EditorMenu.css" );

		var mainContainer = Add.Panel( "mainContainer" ); // didn't know how to name it, just used like a <div> in HTML
		{
			var tabs = AddChild<ButtonGroup>();
			tabs.AddClass( "tabs" );

			var body = Add.Panel( "body" );
			{
				var home = body.AddChild<SpawnList>();
				tabs.SelectedButton = tabs.AddButtonActive( "Home", ( b ) => home.SetClass( "active", b ) );

				//var ents = body.AddChild<EntityList>();
				//tabs.AddButtonActive( "Entities", ( b ) => ents.SetClass( "active", b ) );

				//var models = body.AddChild<CloudModelList>();
				//tabs.AddButtonActive( "s&works", ( b ) => models.SetClass( "active", b ) );
			}
		}
	}

	public override void Tick()
	{
		base.Tick();

		if ( Input.Released( InputButton.Menu ) )
		{
			switch ( menuopen )
			{
				case true:
					menuopen = false;
					break;
				case false:
					menuopen = true;
					break;
			}
			Parent.SetClass( "menu-open", menuopen );
		}
	}

	public override void OnHotloaded()
	{
		base.OnHotloaded();

		//do rebuilding here
	}
}
