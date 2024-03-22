using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillList : MonoBehaviour
{
    private static List<Skill> skillList = new List<Skill>();

     private GameObject fireBall;
    
    void Awake()
    {
        fireBall = Resources.Load<GameObject>("FireBall");
        skillList.Add(new Skill(153, fireBall, new Vector2(1, 0)));
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static Skill getSkillByIndex(int index)
    {
        foreach(Skill sk in skillList){
            if (sk.index == index)
            {
                return sk;
            }
        }

        return null;
    }
}
