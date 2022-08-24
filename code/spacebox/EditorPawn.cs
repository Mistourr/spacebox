using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;

namespace Spacebox
{
	public partial class EditorPawn : Player
	{
		public EditorPawn()
		{
			CameraMode = new FreeCamera();
		}

		public override void Simulate( Client cl )
		{
			UpdatePosition( cl );

			if ( IsClient )
			{
				//Inputs here
			}
		}
		public override void FrameSimulate( Client cl )
		{
			UpdatePosition( cl );
		}

		private void UpdatePosition( Client cl )
		{
			Position = Input.Position;
			Rotation = Input.Rotation;
			EyeRotation = Input.Rotation;
		}
	}
}
