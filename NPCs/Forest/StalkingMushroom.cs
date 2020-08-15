using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EtherealHorizons.Items.Weapons.Melee;
using System.IO;

namespace EtherealHorizons.NPCs.Forest
{
    public class StalkingMushroom : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stalking Mushroom");
            Main.npcFrameCount[npc.type] = 5;
        }

        public override void SetDefaults()
        {
            npc.noTileCollide = false;
            npc.lavaImmune = false;
            npc.width = 38;
            npc.height = 32;
            npc.damage = 10;
            npc.lifeMax = 100;
            npc.knockBackResist = 0f;
            npc.value = Item.sellPrice(copper: 20);
            npc.aiStyle = -1;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }

        private float State 
        { 
            get => npc.ai[0]; 
            set => npc.ai[0] = value; 
        }

        private float ShootTimer 
        { 
            get => npc.ai[3]; 
            set => npc.ai[3] = value; 
        }
        private float LocalTimer
        {
            get => npc.localAI[1];
            set => npc.localAI[1] = value;
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(LocalTimer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            LocalTimer = reader.ReadInt32();
        }

        public override void AI()
        {
            switch ((int)State)
            {
                case 0: // First tick
                    State = 1;
                    npc.netUpdate = true;
                    break;

                case 1: // While it hasn't been attacked or there's no targets
                    if (LocalTimer > 0)
                    {
                        LocalTimer--;
                    }

                    else if (Main.rand.NextBool(1000))
                    {
                        string text;
                        switch (Main.rand.Next(4))
                        {
                            case 1: text = "oweegee"; break;
                            case 2: text = "mushreem"; break;
                            case 3: text = "you are nosy"; break;
                            default: text = "ae"; break;
                        }
                        CombatText.NewText(npc.getRect(), Color.MediumVioletRed, text);
                        LocalTimer = 200;
                    }
                    break;

                case 2:
                    State = 3;
                    ShootTimer = 20;
                    goto case 3;

                // Attack
                case 3:
                    Player target = Main.player[npc.target];
                    if (!target.active || target.dead || target.ghost)
                    {
                        npc.TargetClosest(); // Re-target
                    }

                    target = Main.player[npc.target]; // Re-index
                    if (!target.active || target.dead || target.ghost) // If there's stil no target
                    {
                        break;
                    }

                    if (ShootTimer > 0) // Attack cooldown
                    {
                        ShootTimer--;
                    }

                    else // Attack
                    {
                        int p = Projectile.NewProjectile(npc.Center, Vector2.Normalize(target.MountedCenter - npc.Center) * 5, ProjectileID.SporeGas, npc.damage / 4, 0, Main.myPlayer);
                        Projectile proj = Main.projectile[p];
                        proj.friendly = false;
                        proj.hostile = true;
                        proj.damage = 10;
                        proj.netUpdate = true;
                        ShootTimer = 120;
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
            {
                npc.ai[0] = 2;
            }
            npc.target = player.whoAmI;
        }

        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            if (projectile.npcProj)
            {
                return;
            }

            if (npc.ai[0] < 2)
            {
                npc.ai[0] = 2;
            }
            npc.target = projectile.owner;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            if (npc.ai[0] >= 2)
            {
                if (npc.frameCounter < 15) {
					npc.frame.Y = 0 * frameHeight;
				}
				else if (npc.frameCounter < 30) {
					npc.frame.Y = 1 * frameHeight;
				}
				else if (npc.frameCounter < 45) {
					npc.frame.Y = 2 * frameHeight;
				}
                else if (npc.frameCounter < 60) {
					npc.frame.Y = 3 * frameHeight;
				}
				else {
					npc.frameCounter = 0;
				}
            }
            else
            {
                npc.frame.Y = 4 * frameHeight;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Active ? SpawnCondition.OverworldDay.Chance * 0.2f : 0f;
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.Mushroom, Main.rand.Next(1, 3));
            if (Main.rand.NextBool(20)) // 5% chance
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Mushbat>(), 1);
            }
        }
    }
}
