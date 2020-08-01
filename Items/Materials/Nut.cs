using Terraria;
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
            item.consumable = true;
			item.maxStack = 999;
			item.width = 20;
			item.height = 24;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(copper: 15);
            item.ammo = item.type;
            item.ranged = true;
            item.damage = 2;
            item.shoot = ModContent.ProjectileType<FriendlyNutProj>();
            item.shootSpeed = 4f;
		}
	}
}