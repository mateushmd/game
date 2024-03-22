using System;
using System.Collections;
using System.Collections.Generic;
using _Game._Scripts.Player;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkillControler : MonoBehaviour
{
    private int[] runes = new int[3]; //
    [SerializeField] private int nRune;
    private int skillIndex;

    private Skill skill;
    [SerializeField] private float skillVelocity;
    private InputManager input;

    [SerializeField] private LayerMask enemyLayer;

    void Awake()
    {
        nRune = 0;
        
        input = InputManager.Instance;
    }
    
    private int getSkillIndex()
    {
        string skill = "";
        for (int i = 0; i < runes.Length; i++)
        {
            skill += runes[i];
            runes[i] = 0;
        }

        nRune = 0;
        return Int32.Parse(skill);
    }
    
    private void OnEnable()
    {
        input.skill1.performed += rune1;
        input.skill2.performed += rune2;
        input.skill3.performed += rune3;
        input.skill4.performed += rune4;
        input.skill5.performed += rune5;
    }

    private void rune1(InputAction.CallbackContext context)
    {
        comb(1);
        nRune++;
        testForSkill();
    }
    
    private void rune2(InputAction.CallbackContext context)
    {
        comb(2);
        nRune++;
        testForSkill();
    }
    
    private void rune3(InputAction.CallbackContext context)
    {
        comb(3);
        nRune++;
        testForSkill();
    }
    
    private void rune4(InputAction.CallbackContext context)
    {
        comb(4);
        nRune++;
        testForSkill();
    }
    
    private void rune5(InputAction.CallbackContext context)
    {
        comb(5);
        nRune++;
        testForSkill();
    }

    private void comb(int rune)
    {
        runes[nRune] = rune;
    }

    private void testForSkill()
    {
        if (nRune == 3)
        {
            int test = getSkillIndex();
            Debug.Log(test);
            skill = SkillList.getSkillByIndex(test);
            if(skill != null)
            {
                GameObject temp = Instantiate(skill.skillObject, transform);
                if (skill.sight == ESightType.Targeted)
                {
                    temp.transform.position = (Vector2)transform.position + skill.startingPosition;
                }
                else if (skill.sight == ESightType.Enemy)
                {
                    Collider2D coll = Physics2D.OverlapBox(transform.position, skill.range, 0f, enemyLayer);
                    if (coll != null)
                        temp.transform.position = coll.transform.position;
                }
                else if (skill.sight == ESightType.Player)
                {
                    temp.transform.position = transform.position;
                }
            }
        }
    }
}
