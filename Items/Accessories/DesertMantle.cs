using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.Items.Accessories
{
	public class DesertMantle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desert Mantle");
             Tooltip.SetDefault("Wear the desert's speed and resistance..."
            + "\nIncreased movement speed by 12% and damage reduction by 5%."
            + "\nImmunity to the Mighty Wind debuff");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 30;
            item.height = 28;
            item.rare = ItemRarityID.Blue;
            item.value = Item.buyPrice(0, 1, 15, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        { 
            player.moveSpeed += 0.12f;
            player.endurance += 0.05f;
            player.buffImmune[BuffID.WindPushed] = true;
        }
        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("AntlionChitin"), 15);
            recipe.AddIngredient(ItemID.AntlionMandible, 5);
            recipe.AddIngredient(ItemID.Amber, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}