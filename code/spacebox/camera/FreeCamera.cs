using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;

namespace Spacebox
{
	public class FreeCamera : CameraMode
	{
		Angles LookAngles;
		Vector3 MoveInput;
		float MoveSpeed;

		public override void Update()
		{
			Position += MoveInput.Normal * 300 * RealTime.Delta * Rotation * MoveSpeed;
			Rotation = Rotation.From( LookAngles );
			FieldOfView = 80;
			Viewer = Local.Pawn;
		}

		public override void BuildInput( InputBuilder input )
		{
			MoveInput = input.AnalogMove;
			LookAngles += input.AnalogLook.WithRoll( 0 );

			MoveSpeed = 1.0f;
			if ( input.Down( InputButton.Run ) ) MoveSpeed = 5.0f;
			if ( input.Down( InputButton.Duck ) ) MoveSpeed = 0.2f;

			input.ViewAngles = LookAngles;
			input.Position = Position;

			// input.ClearButtons();
			input.StopProcessing = true;
		}

		public void Focus( Entity ent )
		{
			var bb = ent.WorldSpaceBounds;
			var focusDist = 2.0f;
			var maxSize = new[] { bb.Size.x, bb.Size.y, bb.Size.z }.Max();
			var cameraView = 2.0f * (float)Math.Tan( 0.5f * 0.017453292f * FieldOfView );
			var distance = focusDist * maxSize / cameraView;
			distance += 0.5f * maxSize;
			Position = bb.Center - distance * Rotation.Forward;
		}

	}
}
