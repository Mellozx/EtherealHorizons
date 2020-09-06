using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EtherealHorizons.Items.Weapons.Ranged
{ 
	public class BigIron : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Big Iron");
        }

        public override void SetDefaults()
        {
            item.ranged = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.useTurn = false;
            item.width = 20;
            item.height = 20;
            item.useTime = 40;
            item.useAnimation = 40;
            item.damage = 16; // Low use time, high damage, equivalent exchange :yaby:
            item.knockBack = 3f;
            item.shootSpeed = 8f;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.rare = ItemRarityID.White;
            item.shoot = ProjectileID.Bullet;
            item.UseSound = SoundID.Item11; 
            item.useAmmo = AmmoID.Bullet;
            item.value = Item.sellPrice(silver: 1);
        }   

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar", 8); // A recipe group, basically "You can use either 8 lead bars or 8 iron bars"
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
