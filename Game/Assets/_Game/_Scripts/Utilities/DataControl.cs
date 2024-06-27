using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using _Game.Data;
using UnityEngine;

namespace _Game._Scripts.Utilities
{
    public class DataControl
    {
        private static Data.Player playerData = new Data.Player();

        public static void saveEquipment(Equipment equipment)
        {
            playerData.saveEquipment(equipment);
        }

        public static Equipment getEquipmentOnData()
        {
            return playerData.getEquipmentOnData();
        }

        public static void saveStats(Stats stats)
        {
            playerData.saveStats(stats);
        }

        public static Stats getStatsOnData()
        {
            return playerData.getStatsOnData();
        }

        public static void saveSkillList(SkillList skillList)
        {
            playerData.saveSkillList(skillList);
        }

        public static SkillList getSkillListOnData()
        {
            return playerData.getSkillListOnData();
        }
    }
}