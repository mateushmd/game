using System.Collections;
using System.Collections.Generic;
using _Game._Scripts.Utilities;
using UnityEngine;

public class SkillList : MonoBehaviour
{
     public List<Skill> skillList { get; private set; } = new List<Skill>();
    
     void Awake()
    {
        getOnData();
    }

    public Skill getSkillByIndex(int index)
    {
        foreach(Skill sk in skillList){
            if (sk.index == index)
            {
                return sk;
            }
        }

        return null;
    }
    
    public void saveData()
    {
        DataControl.saveSkillList(this);
    }

    public void getOnData()
    {
        skillList = DataControl.getSkillListOnData().skillList;
    }
}
