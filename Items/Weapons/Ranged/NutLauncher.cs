using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Materials;
using EtherealHorizons.Projectiles.Ranged;

namespace EtherealHorizons.Items.Weapons.Ranged
{
	public class NutLauncher : ModItem 
	{ 
		public override void SetStaticDefaults() 
		{ 
			DisplayName.SetDefault("Nut Launcher"); 
            Tooltip.SetDefault("Uses nuts as ammo");
		}

        public override void SetDefaults()
        {
			item.ranged = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.width = 20;
			item.height = 20;
			item.useTime = 20;
			item.useAnimation = 20;
			item.UseSound = SoundID.Item56;
			item.damage = 5;
			item.knockBack = 1f;
			item.shootSpeed = 8f;
			item.shoot = ModContent.ProjectileType<FriendlyNutProj>();
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(copper: 40);
			item.useAmmo = ModContent.ItemType<Nut>();
        }

		public override void AddRecipes()
        {
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 12);
			recipe.AddIngredient(ModContent.ItemType<Nut>(), 4);
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