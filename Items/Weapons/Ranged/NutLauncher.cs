using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Projectiles.Ranged;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Weapons.Ranged
{
	public class NutLauncher : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nut Launcher");
		}
		
		public override void SetDefaults()
		{
			item.noMelee = true;
			item.ranged = true;
			item.autoReuse = true;
			item.useTurn = false;
			item.width = 20;
			item.height = 20;
			item.useTime = 28;
			item.useAnimation = 28; 
			item.damage = 4;
			item.knockBack = 0f;
			item.shoot = ModContent.ItemType<FriendlyNutProjectile>();
			item.shootSpeed = 8f;
			item.UseSound = SoundID.Item56;
			item.useAmmo = ModContent.ItemType<Nut>();
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(copper: 40);
		}
		
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 15);
			recipe.AddIngredient(ModContent.ItemType<Leaf>(), 5);
			recipe.AddIngredient(ModContent.ItemType<Nut>(), 2);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2f, -4f);
		}
	}
}