using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Projectiles.Melee;

namespace EtherealHorizons.Items.Weapons.Melee
{
	public class CheekCrusher : ModItem
	{
		public static float speed = 16f;
		public static bool stomp;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cheek Crusher");
			Tooltip.SetDefault("Will create a stomp attack, dealing area damage after 6 attacks. However, the attacks count will" + "\nbe reseted to 0 once the stomp attack happens");
		}
		
		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.width = 40;
			item.height = 40;
			item.damage = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 5f;
			item.autoReuse = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.melee = true;
			item.shootSpeed = speed;
			item.shoot = ModContent.ProjectileType<CheekCrusherProjectile>();
			item.rare = ItemRarityID.Blue;
		}
	}
}