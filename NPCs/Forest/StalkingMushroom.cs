using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EtherealHorizons.NPCs.Forest
{
    public class StalkingMushroom : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stalking Mushroom");
        }

        public override void SetDefaults()
        {
            npc.width = 38;
            npc.height = 32;
            npc.damage = 10;
            npc.lifeMax = 100;
            npc.knockBackResist = 0f;
            npc.HitSound = new LegacySoundStyle( 3, 1);
            npc.DeathSound = new LegacySoundStyle(4, 32);
        }

        private float state { get => npc.ai[0]; set => npc.ai[0] = value; }
        //private float timer { get => npc.ai[1]; set => npc.ai[1] = value; }
        //private float jumptimer { get => npc.ai[2]; set => npc.ai[2] = value; }
        private float shootTimer { get => npc.ai[3]; set => npc.ai[3] = value; }

        public override void AI()
        {
            switch ((int)state)
            {
                case 0: // first tick
                    state = 1;
                    npc.netUpdate = true;
                    break;

                case 1: // while it hasn't been attacked or deres no targets
                    break;

                case 2:
                    state = 3;
                    shootTimer = 20;
                    goto case 3;

                case 3: // attack
                    Player target = Main.player[npc.target];
                    if (!target.active || target.dead || target.ghost)
                        npc.TargetClosest(); // retarget
                    target = Main.player[npc.target]; // reindex
                    if (!target.active || target.dead || target.ghost) // if still no target
                        goto case 1;

                    if (shootTimer > 0) // atacc cooldown
                        shootTimer--;
                    else // attack
                    {
                        int p = Projectile.NewProjectile(npc.Center, Vector2.Normalize(target.MountedCenter - npc.Center) * 5, ProjectileID.SporeGas, npc.damage / 4, 0, Main.myPlayer);
                        Projectile proj = Main.projectile[p];
                        proj.friendly = false;
                        proj.hostile = true;
                        proj.damage = 10;
                        proj.netUpdate = true;
                        shootTimer = 120;
                    }

                    break;
            }
        }

        public override bool? CanHitNPC(NPC target)
        {
            return npc.ai[0] <= 2 ? false : base.CanHitNPC(target);
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            return npc.ai[0] > 2;
        }

        public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
        {
            if (npc.ai[0] < 2)
                npc.ai[0] = 2;
            npc.target = player.whoAmI;
        }

        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            if (projectile.npcProj)
                return;
            if (npc.ai[0] < 2)
                npc.ai[0] = 2;
            npc.target = projectile.owner;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Active ? SpawnCondition.OverworldDay.Chance * 0.2f : 0f;
        }
    }
}
