using EtherealHorizons.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Accessories
{
	public class EvergreenAegis : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Evergreen Aegis");
            Tooltip.SetDefault("Defense increased by 3 when you are below half of your life");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 20;
            item.height = 20;
            item.defense = 3;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(silver: 25);
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<EtherealPlayer>().evergreenAegis = true;
            if (player.statLife <= player.statLifeMax2 / 2)
            {
                player.statDefense += 3;
            }
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 15);
            recipe.AddIngredient(ItemID.StoneBlock, 15);
            recipe.AddRecipeGroup("IronBar", 8);
            recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 6);
            recipe.AddTile(TileID.Anvils);
        }
    }
}