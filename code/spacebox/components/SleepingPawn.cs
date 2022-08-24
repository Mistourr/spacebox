using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;

namespace Spacebox
{
	class SleepingPawn : EntityComponent
	{
		SandboxPlayer pawn;
		public void SetPawn(SandboxPlayer pawn )
		{
			this.pawn = pawn;
		}
		public SandboxPlayer GetPawn()
		{
			return this.pawn;
		}
	}
}
