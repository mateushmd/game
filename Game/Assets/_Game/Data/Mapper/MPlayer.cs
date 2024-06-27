using _Game._Scripts.Utilities;
using UnityEngine;

namespace _Game.Data.Mapper
{
    public class MPlayer
    {
        public static Equipment MapEquipment(DEquipment dEquiment)
        {
            Equipment equipment = new Equipment();
            
            equipment.switchWeapon(dEquiment.weapon);
            return equipment;
        }

        public static DEquipment MapEquipment(Equipment equipment)
        {
            DEquipment dEquipment = new DEquipment();
            
            dEquipment.weapon = equipment.weapon;
            return dEquipment;
        }

        public static Stats MapStats(DStats dStats)
        {
            Stats stats = new Stats();
            
            stats.buffMaxHP("", dStats.maxHP, 0);
            stats.buffMaxMP("", dStats.maxMP, 0);
            stats.buffInteligence("", dStats.inteligence, 0);
            stats.buffAgility("", dStats.agility, 0);
            stats.buffDefense("", dStats.defense, 0);
            stats.buffDexterity("", dStats.dexterity, 0);
            stats.buffForce("", dStats.force, 0);
            stats.buffMagicDefense("", dStats.magicDefense, 0);
            stats.buffWindResistence("", dStats.windResistence, 0);
            stats.buffWaterResistence("", dStats.waterResistence, 0);
            stats.buffEarthResistence("", dStats.earthResistence, 0);
            stats.buffFireResistence("", dStats.fireResistence, 0);
            stats.buffWindBonus("", dStats.windBonus, 0);
            stats.buffWaterBonus("", dStats.waterBonus, 0);
            stats.buffEarthBonus("", dStats.earthBonus, 0);
            stats.buffFireBonus("", dStats.fireBonus, 0);
            
            return stats;
        }

        public static DStats MapStats(Stats stats)
        {
            DStats dStats = new DStats();

            dStats.maxHP = stats.maxHP;
            dStats.maxMP = stats.maxMP;
            dStats.inteligence = stats.inteligence;
            dStats.agility = stats.agility;
            dStats.defense = stats.defense;
            dStats.dexterity = stats.dexterity;
            dStats.force = stats.force;
            dStats.magicDefense = stats.magicDefense;
            dStats.windResistence = stats.windResistence;
            dStats.waterResistence = stats.waterResistence;
            dStats.earthResistence = stats.earthResistence;
            dStats.fireResistence = stats.fireResistence;
            dStats.windBonus = stats.windBonus;
            dStats.waterBonus = stats.waterBonus;
            dStats.earthBonus = stats.earthBonus;
            dStats.fireBonus = stats.fireBonus;

            return dStats;
        }

        public static DSkillList MapSkillList(SkillList skillList)
        {
            DSkillList dSkillList = new DSkillList();

            //dSkillList.skillList = skillList.skillList;
            foreach (Skill skill in skillList.skillList)
            {
                dSkillList.skillList.Add(new DSkill(skill.name, skill.index, new DVector2(skill.startingPosition.x, skill.startingPosition.y), skill.sight, new DVector2(skill.range.x, skill.range.y), skill.cooldownTime, skill.cooldown));
            }

            return dSkillList;
        }

        public static SkillList MapSkillList(DSkillList dSkillList)
        {
            SkillList skillList = new SkillList();

            foreach (DSkill skill in dSkillList.skillList)
            {
                Debug.Log(skill.name);
                skillList.skillList.Add(new Skill(skill.name, skill.index, new Vector2(skill.startingPosition.x, skill.startingPosition.y), skill.sight, new Vector2(skill.range.x, skill.range.y), skill.cooldownTime, skill.cooldown));
            }

            return skillList;
        }
    }
}