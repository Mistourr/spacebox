using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;
using Sandbox.UI;

namespace Spacebox
{
	public class HudComponent : EntityComponent
	{
		HudEntity<RootPanel> hud;
		public HudEntity<RootPanel> GetHud()
		{
			return hud;
		}
		public void SetHud(HudEntity<RootPanel> newhud)
		{
			hud = newhud;
		}
	}
}
