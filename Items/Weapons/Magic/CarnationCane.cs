using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Items.Weapons.Magic
{
	public class CarnationCane : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Carnation Cane"); 
            Item.staff[item.type] = true;
		}
        public override void SetDefaults()
		{
			item.damage = 16;
			item.width = 38;
			item.height = 38;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 5;
			item.value = Item.buyPrice(0, 0, 12, 10);
			item.rare = 5;
			item.knockBack = 2;
			item.noMelee = true;
			item.mana = 8;
			item.UseSound = SoundID.Item20;
			item.shoot = mod.ProjectileType("FlowerProj");
			item.shootSpeed = 8f;
			item.autoReuse = true;
			item.magic = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<AncientTwig>(), 5); //modded materials
			recipe.AddIngredient(ItemID.YellowMarigold, 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}