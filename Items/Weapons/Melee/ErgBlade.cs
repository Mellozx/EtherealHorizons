using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Materials;
using EtherealHorizons.Projectiles.Melee;
using System.Collections.Generic;

namespace EtherealHorizons.Items.Weapons.Melee
{
	public class ErgBlade : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Erg's Blade");
		}

		public override void SetDefaults() 
		{
			item.damage = 14;
			item.melee = true;
			item.useTurn = false;
			item.width = 48;
			item.height = 52;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4f;
			item.value = Item.buyPrice(0, 0, 20, 12);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
		}
        public override void AddRecipes()
        {
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DustiliteChunk>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}