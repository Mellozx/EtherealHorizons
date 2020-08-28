using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Items.Accessories
{
	[AutoloadEquip(EquipType.Head)]
	public class CrownOfTheDesert : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crown of the Desert");
             Tooltip.SetDefault("Wear the desert's power and might..." + "\nIncreased all critical strike chance and damage by 3%");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 30;
            item.height = 28;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(silver: 50);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        { 
            player.magicCrit += 3;
            player.meleeCrit += 3;
            player.rangedCrit += 3;
            player.thrownCrit += 3;
            player.allDamage += 0.03f;
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