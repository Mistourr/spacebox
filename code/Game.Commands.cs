using Sandbox;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using Spacebox;
using System.Collections.Generic;

partial class SandboxGame : Game
{
	[ConCmd.Server( "ship_editor" )]
	public static void ShipEditorCommand( string arg )
	{
		var cl = ConsoleSystem.Caller;
		if ( arg.ToLower() == "open" )
		{
			if ( cl.Pawn is not EditorPawn )
			{
				cl.Pawn = new EditorPawn();
			}
		}
		else if ( arg.ToLower() == "close" )
		{
			if ( cl.Pawn is EditorPawn )
			{
				var ply = cl.Pawn;
				cl.Pawn = cl.Components.Get<SleepingPawn>( true ).GetPawn(); // We get the original pawn back through the client's custom component
				ply.Delete(); // Delete the editor pawn to avoid duplication
			}
		}
		else if(arg.ToLower() == "help"){
			var msg = "- help : displays all commands and how to use them.\n" +
				"- open : opens the ship editor\n" +
				"- close : closes the ship editor";
			Log.Info( msg );
		}
		else
		{
			Log.Error( "Ship Editor : No valid options were given, type help for a list of options" );
		}
	}
}
