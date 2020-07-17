using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EtherealHorizons.Events;

namespace EtherealHorizons.Events.ForestFrenzy
{
    public class ForestFrenzy : ModEvent
    {
        //private class TestCommand : ModCommand
        //{
        //    public override string Command => "FFT";

        //    public override CommandType Type => CommandType.Chat;

        //    public override void Action(CommandCaller caller, string input, string[] args)
        //    {
        //        if(args.Length < 0)
        //        {
        //            Main.NewText("Type 'true/'false'/'start'/'end'");
        //            return;
        //        }

        //        if(bool.TryParse(args[0], out bool flag))
        //        {
        //            if (flag)
        //                ModEvent.StartEvent<ForestFrenzy>();
        //            else
        //                ModEvent.EndEvent<ForestFrenzy>();
        //        }
        //        else switch (args[0].ToLower())
        //        {
        //            case "start":
        //                ModEvent.StartEvent<ForestFrenzy>();
        //                break;
        //            case "end":
        //                ModEvent.EndEvent<ForestFrenzy>();
        //                break;
        //            default:
        //                Main.NewText("Type 'true/'false'/'start'/'end'");
        //                break;
        //        }
        //    }
        //}
        public override void OnStart()
        {
            //Helpers.NewTextSync("The Forest Frenzy is starting!", Color.ForestGreen);
        }

        public override void Update()
        {
            // Making other stuff happen
        }

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            // Enemies that can spawn
        }

        public override void OnKillNPC(NPC npc)
        {
            // when any NPC dies during the event
        }

        public override void OnEnd()
        {
            //Helpers.NewTextSync("The Forest Frenzy has ended", Color.ForestGreen);
        }
    }
}
