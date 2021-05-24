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
            List<Transform> result = new List<Transform>();
            BarricadeManager.getBarricadesInRadius(position, radius, result);

                foreach (Transform transform in result)
                {
                    if (BarricadeManager.tryGetInfo(transform, out byte x, out byte y, out ushort plant, out ushort index, out BarricadeRegion region))
                    {
                        BarricadeManager.destroyBarricade(region, x, y, plant, index);
                        
                        destroyCount++;
                    }
                }
            return destroyCount;
        }


        public override TranslationList DefaultTranslations => new TranslationList()
        {
            {"command_get_experience_help", "/exp [nick] [count] <color=yellow>или</color> /exp [count]" },
            {"command_get_experience_to_player_successfully", "Вы получили опыт от <color=red>{0}</color>, в размере: <color=green>{1}</color> ед." },
            {"command_get_experience_successfully", "Вы успешно выдали себе опыт." },
            {"command_get_experience_to_player", "Вы успешно выдали опыт игроку <color=red>{0}</color>, в размере: <color=green>{1}</color> ед." },
            {"command_get_experience_failed", "Не удалось выдать опыт." },
            {"command_get_experience_to_player_not_found", "Игрок не найден!" },

            {"command_max_skills_successfully", "<color=red>M</color><color=#FFA500>a</color><color=yellow>x</color><color=green>S</color><color=#00FFFF>k</color><color=blue>i</color><color=#FF00FF>l</color><color=red>l</color><color=#FFA500>s</color> ^_^" },

            {"command_share_successfully", "Вы успешно передали <color=green>{0}</color> ед. опыта, игроку <color=yellow>{1}</color>." },
            {"command_share_to_player_successfully", "Игрок <color=yellow>{0}</color> передал Вам <color=green>{1}</color> ед. опыта." },
            {"command_share_failed", "Не удалось передать опыт." },
            {"command_share_help", "/share [nick] [count]" },

            {"command_clear_inventory_successfully", "Инвентарь очищен." }



        };

        

    }
}
