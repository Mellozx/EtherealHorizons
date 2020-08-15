using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EtherealHorizons.NPCs.Bosses.AwakeCheeks;
using System.Collections.Generic;
using Terraria.Localization;

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

        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
        }

        public override void AddRecipeGroups()
        {
            var group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + "Gold Crown", new int[]
            {
                ItemID.GoldCrown,
                ItemID.PlatinumCrown
            });
            RecipeGroup.RegisterGroup("EtherealHorizons:GoldCrown", group);
        }
    }
}