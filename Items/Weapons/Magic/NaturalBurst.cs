using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Items.Materials;
using Microsoft.Xna.Framework;
using EtherealHorizons.Projectiles.Magic;

namespace EtherealHorizons.Items.Weapons.Magic
{
	public class NaturalBurst : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Natural Burst"); 
            Item.staff[item.type] = true;
		}
        public override void SetDefaults()
		{
			item.damage = 15;
			item.width = 26;
			item.height = 36;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = Item.buyPrice(silver: 26);
			item.rare = ItemRarityID.Blue;
			item.knockBack = 5;
			item.noMelee = true;
			item.mana = 8;
			item.UseSound = SoundID.Item20;
			item.shoot = ModContent.ProjectileType<SineWaveLeaf>();
			item.shootSpeed = 8f;
			item.autoReuse = true;
			item.magic = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WildlifeFragment>(), 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}