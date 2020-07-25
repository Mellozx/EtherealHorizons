using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EtherealHorizons.NPCs.Bosses.AwakeCheeks
{
	public class AwakeCheeksDeath : ModNPC
    {
		public override string Texture => "EtherealHorizons/PLACEHOLDER";
		
        private Player player;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Awake Cheeks");
        }

        public override void SetDefaults()
        {
            npc.lavaImmune = true;
            npc.dontTakeDamage = true;
            npc.noTileCollide = false;
            npc.defense = 12;
            npc.damage = 0;
            npc.knockBackResist = 0f;
            npc.width = 80;
            npc.height = 80;
            npc.timeLeft = 300;
        }

        public override void AI()
        {
            Target();

            Collision.StepUp(ref npc.position, ref npc.velocity, npc.width, npc.height, ref npc.stepSpeed, ref npc.gfxOffY);
            if (npc.velocity.Y == 0f)
            {
                if (npc.velocity.X < 0f || npc.velocity.X > 0f)
                {
                    int stepX = (int)(npc.position.X + (npc.width / 2)) / 16;
                    int stepY = (int)(npc.position.Y + (npc.height / 2)) / 16 + 1;
                    WorldGen.SolidTile(stepX, stepY);
                }
            }

            // Scared
            if (npc.ai[0] == 0f)
            {
                npc.velocity = new Vector2(0f, 0f);

                npc.ai[2] += 1f;
                if (npc.ai[2] >= 120)
                {
                    npc.ai[0] = 1f;
                }
            }

            // Running (Ight, imma head out)
            else if (npc.ai[0] == 1f)
            {
                MoveAgainstPlayerX(6f, 4);
            }
        }

        private void MoveAgainstPlayerX(float speed, float distance)
        {
            if (npc.position.X - distance > player.position.X)
            {
                npc.velocity.X = speed;
            }
            else if (npc.position.X + distance < player.position.X)
            {
                npc.velocity.X = -speed;
            }
            else
            {
                npc.velocity.X = 0f;
            }
        }

        private void Target()
        {
            player = Main.player[npc.target];
        }
    }
}