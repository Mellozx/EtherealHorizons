using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EtherealHorizons.Projectiles.Melee.Spears
{
	public class SharpnutSpearProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sharpnut Spear");
		}

		public override void SetDefaults() {
			projectile.width = 28;
			projectile.height = 28;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.1f;
			projectile.alpha = 0;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}

		
		public float movementFactor 
		{
			get => projectile.ai[0];
			set => projectile.ai[0] = value;
		}

		
		public override void AI() {
			
			Player projOwner = Main.player[projectile.owner];
			Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			projectile.direction = projOwner.direction;
			projOwner.heldProj = projectile.whoAmI;
			projOwner.itemTime = projOwner.itemAnimation;
			projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
			projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
			if (!projOwner.frozen) {
				if (movementFactor == 0f) 
				{
					movementFactor = 3f; 
					projectile.netUpdate = true; 
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3) 
				{
					movementFactor -= 3f;
				}
				else 
				{
					movementFactor += 2f;
				}
			}
			projectile.position += projectile.velocity * movementFactor;
			if (projOwner.itemAnimation == 0) {
				projectile.Kill();
			}			
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
			if (projectile.spriteDirection == -1) {
				projectile.rotation -= MathHelper.ToRadians(90f);
			}
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
                //base damage is rather weak, so this spear will ignore some defense 
			damage += (int)((target.defense / 3));
		}
	}
}