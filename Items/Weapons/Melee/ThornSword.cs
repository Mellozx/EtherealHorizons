using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Weapons.Melee
{
	public class ThornSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Thorn Sword");
            Tooltip.SetDefault("May poison the target");
		}

		public override void SetDefaults() 
		{
			item.damage = 10;
			item.melee = true;
			item.width = 56;
			item.height = 60;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 6f;
			item.value = Item.sellPrice(copper: 48);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
            item.scale = 1.1f;
		}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) 
        {
			target.AddBuff(BuffID.Poisoned, 60);
		}
        public override void AddRecipes()
        {
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Sandstone, 13);
            recipe.AddIngredient(mod.ItemType("Thorn"), 4);
			recipe.AddIngredient(ItemID.Cactus, 8);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}