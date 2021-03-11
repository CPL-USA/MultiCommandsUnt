using Rocket.API.Collections;
using Rocket.Core.Plugins;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCommands
{
    public class MultiCommands : RocketPlugin
    {
        public static MultiCommands Instance;

        protected override void Load()
        {
            Instance = this;
        }

        protected override void Unload()
        {
            
        }


        public override TranslationList DefaultTranslations => new TranslationList()
        {
            {"command_maxskills_successfully", "MaxSkills ^_^" },
            {"command_ci_successfully", "Инвентарь очищен." },
        };

        

    }
}
