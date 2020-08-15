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
			item.autoReuse = false;
			item.width = 38;
			item.height = 42;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3f;
			item.value = Item.sellPrice(silver: 20);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (Main.rand.NextBool(10)) // 10% chance
			{
				Projectile.NewProjectile(target.Center, Vector2.Zero, ProjectileID.SandnadoFriendly, damage / 4, knockBack, player.whoAmI);
			}
		}	
	}
}