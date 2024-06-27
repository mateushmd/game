using System;
using System.IO;
using _Game._Scripts.Player;
using _Game._Scripts.Utilities;
using _Game.Data.Mapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UnityEngine;

namespace _Game.Data
{
    [Serializable]
    public class Player
    {
        public DEquipment dEquipment { get; private set; } = new DEquipment();
        public DStats dStats { get; private set; } = new DStats();
        public DSkillList dSkillList { get; private set; } = new DSkillList();
        private string playerPath = "Assets/_Game/Data/JsonStorage/Player.json";

        public void saveEquipment(Equipment equipment)
        {
            dEquipment = MPlayer.MapEquipment(equipment);
            dStats = getDStatsOnData();
            dSkillList = getDSkillListOnData();
            using (StreamWriter sw = new StreamWriter(playerPath))
            {
                sw.WriteLine(JsonConvert.SerializeObject(this, Formatting.Indented));
            }
        }

        public Equipment getEquipmentOnData()
        {
            string strJson = "";
            using (StreamReader sr = new StreamReader(playerPath))
            {
                strJson = sr.ReadToEnd();
            }

            return MPlayer.MapEquipment(getDEquipmentOnData());
        }

        private DEquipment getDEquipmentOnData()
        {
            string strJson = "";
            using (StreamReader sr = new StreamReader(playerPath))
            {
                strJson = sr.ReadToEnd();
            }
            

            return JsonConvert.DeserializeObject<Player>(strJson).dEquipment;
        }

        public void saveStats(Stats stats)
        {
            dStats = MPlayer.MapStats(stats);
            dEquipment = getDEquipmentOnData();
            dSkillList = getDSkillListOnData();
            using (StreamWriter sw = new StreamWriter(playerPath))
            {
                sw.WriteLine(JsonConvert.SerializeObject(this, Formatting.Indented));
            }
        }
        
        public Stats getStatsOnData()
        {
            string strJson = "";
            using (StreamReader sr = new StreamReader(playerPath))
            {
                strJson = sr.ReadToEnd();
            }

            return MPlayer.MapStats(getDStatsOnData());
        }

        private DStats getDStatsOnData()
        {
            string strJson = "";
            using (StreamReader sr = new StreamReader(playerPath))
            {
                strJson = sr.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<Player>(strJson).dStats;
        }
        
        public void saveSkillList(SkillList skillList)
        {
            dSkillList = MPlayer.MapSkillList(skillList);
            dEquipment = getDEquipmentOnData();
            dStats = getDStatsOnData();
            using (StreamWriter sw = new StreamWriter(playerPath))
            {
                sw.WriteLine(JsonConvert.SerializeObject(this, Formatting.Indented));
            }
        }

        public SkillList getSkillListOnData()
        {
            /*string strJson = "";
            using (StreamReader sr = new StreamReader(playerPath))
            {
                strJson = sr.ReadToEnd();
            }*/
            
            return MPlayer.MapSkillList(getDSkillListOnData());
        }

        private DSkillList getDSkillListOnData()
        {
            string strJson = "";
            using (StreamReader sr = new StreamReader(playerPath))
            {
                strJson = sr.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<Player>(strJson).dSkillList;
        }
    }
}