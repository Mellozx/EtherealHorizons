using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Items.Accessories
{
	public class CrownOfTheDesert : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crown of the Desert");
             Tooltip.SetDefault("Wear the desert's power and might..." + "\nIncreased all crit chance and damage by 5%");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 30;
            item.height = 28;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(silver: 60);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        { 
            player.magicCrit += 5;
            player.meleeCrit += 5;
            player.rangedCrit += 5;
            player.thrownCrit += 5;
            player.allDamage += 0.05f;
        }
        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sandstone, 8);
            recipe.AddIngredient(ItemID.Amber, 3);
            recipe.AddIngredient(ItemID.AntlionMandible, 3);
            recipe.AddRecipeGroup("EtherealHorizons:GoldCrown", 1);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}