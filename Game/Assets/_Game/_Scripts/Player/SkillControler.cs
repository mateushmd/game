using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillControler : MonoBehaviour
{
    private int[] runes = new int[5]; //
    [SerializeField] private int nRune;
    private int skillIndex;

    [SerializeField] private GameObject skill;
    [SerializeField] private Transform ss; //ShotSkill
    [SerializeField] private float skillVelocity;
    
    // Start is called before the first frame update
    void Awake()
    {
        nRune = 0;

        runes[0] = 1;
        runes[1] = 5;
        runes[2] = 5;
        runes[3] = 5;
        runes[4] = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (nRune == 4)
        {
            int test = getSkillIndex();
            Debug.Log(test);
            skill = SkillList.getSkillByIndex(test);
            GameObject temp = Instantiate(skill);
            temp.transform.position = ss.position;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(skillVelocity, 0);
        }
    }

    private int getSkillIndex()
    {
        string skill = "";
        for (int i = 0; i < runes.Length; i++)
        {
            skill += runes[i];
            //runes[i] = 0;
        }

        return Int32.Parse(skill);
    }
}
