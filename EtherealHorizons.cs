using System;
using Terraria;
using Terraria.ModLoader;
using EtherealHorizons.NPCs.Bosses.AwakeCheeks;
using System.Collections.Generic;

namespace EtherealHorizons
{
    public class EtherealHorizons : Mod
    {
        public static EtherealHorizons instance;

        public EtherealHorizons()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true,
                AutoloadBackgrounds = true
            };
        }

        public override void Load()
        {
            instance = this;
		}

        public override void Unload()
        {
            instance = null;
        }
    }
}