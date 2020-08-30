using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.Projectiles.Ranged;

namespace EtherealHorizons.Items.Materials
{
	public class Nut : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nut");
		}
		
		public override void SetDefaults()
		{
			item.material = true;
			item.ranged = true;
			item.maxStack = 999;
			item.width = 20;
			item.height = 20;
			item.damage = 2;
			item.rare = ItemRarityID.White;
			item.ammo = item.type;
			item.shoot = ModContent.ProjectileType<FriendlyNutProjectile>();
			item.shootSpeed = 6f;
		}
	}
}