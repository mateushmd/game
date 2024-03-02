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
        skillList.Add(new Skill(15553, fireBall));
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static GameObject getSkillByIndex(int index)
    {
        foreach(Skill sk in skillList){
            if (sk.index == index)
            {
                return sk.skillObject;
            }
        }

        return null;
    }
}

class Skill
{
    public int index { get; private set; }
    public GameObject skillObject { get; private set; }

    public Skill(int i, GameObject so)
    {
        index = i;
        skillObject = so;
    }
}
