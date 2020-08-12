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
	public class AncientShrineItem : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Shrine");
		}

		public override void SetDefaults()
		{
			item.width = 44;
			item.height = 30;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 20;
			item.useTime = 20;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("AncientShrine");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("HardenedWood"), 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}