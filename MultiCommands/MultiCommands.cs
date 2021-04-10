using Rocket.API.Collections;
using Rocket.Core.Plugins;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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

        public int DestroyBarricadesInRadius(Vector3 position, float radius)
        {
            int destroyCount = 0;
            List<Transform> result = null;
            BarricadeManager.getBarricadesInRadius(position, radius, result);
            if (result != null)
            {

                foreach (Transform transform in result)
                {
                    if (BarricadeManager.tryGetInfo(transform, out byte x, out byte y, out ushort plant, out ushort index, out BarricadeRegion region))
                    {
                        BarricadeManager.destroyBarricade(region, x, y, plant, index);
                        destroyCount++;
                    }
                }
            }
            return destroyCount;
        }


        public override TranslationList DefaultTranslations => new TranslationList()
        {
            {"command_maxskills_successfully", "MaxSkills ^_^" },

            {"command_ci_successfully", "Инвентарь очищен." },

            {"experience_error", "/exp [опыт] или /exp [опыт] [nick]"},
            {"experience_successfully", "Опыт успешно выдан!"},
            {"exp_player_not_found", "Игрок {0} не найден!" },
            {"exp_toplayer", "Игрок {0}  выдал вам {1} опыта." },
            {"exp_give_player", "Вы успешно выдали {0} опыта игроку {1}" },


            {"command_share_not_found_player", "/share [Experience] [Nickname]"},
            {"command_share_insufficient_experience", "У Вас нет такого количества опыта." },
            {"command_share_experience", "Вы успешно передали {0} опыта, игроку {1}"},
            {"command_share_get_experience", "Вы получили {0} опыта от {1}" },
            {"command_share_player2_not_found", "{0} нет на сервере." },
        };

        

    }
}
