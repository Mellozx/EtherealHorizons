using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EtherealHorizons.Items.Tiles
{
	public class SerpentBanner : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Serpent Banner");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 48;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 20;
			item.useTime = 20;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("SerpentBanner");
		}
	}
}