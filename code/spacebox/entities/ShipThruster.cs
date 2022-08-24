using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;

namespace Sandbox.spacebox.entities
{
	[Spawnable]
	[Library( "ent_shipthruster", Title = "Ship Thruster" )]
	internal class ShipThruster : Prop, IUse
	{
		public bool isOn = false;
		public float impulse = 12.0f;

		public override void Spawn()
		{
			base.Spawn();
			SetModel( "models/spacebox/thruster.vmdl" );
		}

		public bool OnUse( Entity user )
		{
			switch ( isOn )
			{
				case true:
					isOn = false;
					Log.Info( "thruster off" );
					break;
				case false:
					isOn = true;
					Log.Info( "thruster on" );
					break;
			}
			return false;
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );
			if ( isOn )
			{
				MoveWithVelocity( Rotation.Forward * impulse, 1);
			}
		}

		public bool IsUsable( Entity user )
		{
			return true;
		}
	}
}
