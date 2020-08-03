using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EtherealHorizons.Items.Materials;
using EtherealHorizons.Projectiles.Melee;

namespace EtherealHorizons.Items.Weapons.Melee
{
	public class AridSlicer : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Arid Slicer");
			Tooltip.SetDefault("Has a chance of spawning an ancient storm on enemy hits");
		}

		public override void SetDefaults() 
		{
			item.damage = 15;
			item.melee = true;
			item.width = 38;
			item.height = 42;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 5f;
			item.value = Item.buyPrice(0, 0, 22, 20);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.scale = 1.1f;
			} 
			public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
			{
				if(Main.rand.Next(15) > 10)
				{
					 Projectile.NewProjectile(target.Center, Vector2.Zero, ProjectileID.SandnadoFriendly, damage / 4, knockBack, player.whoAmI);
				}
			}
	}
}