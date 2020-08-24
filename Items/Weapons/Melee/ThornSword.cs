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
            Tooltip.SetDefault("Has a 50% chance to inflict poisoned on the target");
		}

		public override void SetDefaults() 
		{
			item.damage = 10;
			item.melee = true;
			item.width = 56;
			item.height = 60;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2f;
			item.value = Item.sellPrice(copper: 50);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
		}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) 
        {
			if (Main.rand.NextBool(2))
            {
				target.AddBuff(BuffID.Poisoned, 60);
			}
		}
        public override void AddRecipes()
        {
			var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Thorn>(), 4);
			recipe.AddIngredient(ItemID.Cactus, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}