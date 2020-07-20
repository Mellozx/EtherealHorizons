using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
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
			item.ranged = true;
			item.noMelee = true;
			item.autoReuse = false;
			item.width = 20;
			item.height = 20;
			item.useTime = 22;
			item.useAnimation = 30;
			item.reuseDelay = 14;
			item.damage = 5;
			item.knockBack = 2f;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(silver: 4);
			item.useAmmo = ModContent.ItemType<Nut>();
        }

        public override bool ConsumeAmmo(Player player)
        {
			return !(player.itemAnimation < item.useAnimation - 2);
        }

        public override void AddRecipes()
        {
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 20);
			recipe.AddIngredient(ModContent.ItemType<Nut>(), 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}