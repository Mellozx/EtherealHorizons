using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Weapons.Ranged
{
	public class BarkBallista : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bark Ballista");
		}
		
		public override void SetDefaults()
		{
			item.ranged = true;
			item.noMelee = true;
			item.useTurn = false;
			item.autoReuse = false;
			item.width = 20;
			item.height = 20;
			item.useTime = 30;
			item.useAnimation = 30; 
			item.damage = 25;
			item.knockBack = 3f;
			item.shootSpeed = 8f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.rare = ItemRarityID.Blue;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.UseSound = SoundID.Item5;
			item.useAmmo = AmmoID.Arrow;
			item.value = Item.sellPrice(silver: 40);
		}
		
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 4);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}