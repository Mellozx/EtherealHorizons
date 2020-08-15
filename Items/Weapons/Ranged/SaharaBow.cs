using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using EtherealHorizons.Projectiles.Ranged;
using EtherealHorizons.Items.Materials;

namespace EtherealHorizons.Items.Weapons.Ranged
{
	public class SaharaBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Sahara");
			Tooltip.SetDefault("Converts wooden arrows to arid arrows");
		}
		public override void SetDefaults()
		{
			item.damage = 13;
			item.ranged = true;
			item.width = 22;
			item.height = 56;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 1;
			item.value = Item.sellPrice(silver: 20);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.useAmmo = AmmoID.Arrow;;
			item.shoot = 1;
			item.shootSpeed = 10f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly) 
            {
                type = ModContent.ProjectileType<AridArrowProjectile>(); 
            }
			return true; 
        }
    }
}            