using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillList : MonoBehaviour
{
    private static List<GameObject> skillList;

    [SerializeField] private GameObject fireBall;
    
    void Awake()
    {
        skillList.Add(fireBall);
        //skillList.Insert(15553, fireBall);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static GameObject getSkillByIndex(int index)
    {
        return skillList[index];
    }
}
