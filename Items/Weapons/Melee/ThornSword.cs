using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Materials;
using EtherealHorizons.Projectiles.Melee;

namespace EtherealHorizons.Items.Weapons.Melee
{
	public class ThornSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Thorn Sword");
		}

		public override void SetDefaults() 
		{
			item.damage = 9;
			item.melee = true;
			item.width = 56;
			item.height = 60;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 5f;
			item.value = Item.buyPrice(0, 0, 3, 16);
			item.rare = 0;
			item.UseSound = SoundID.Item1;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) 
		{
			target.AddBuff(BuffID.Poisoned, 180);
		}
        public override void AddRecipes()
        {
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("WildlifeFragment"), 4);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}