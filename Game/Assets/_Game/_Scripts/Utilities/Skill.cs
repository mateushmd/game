using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public int index { get; private set; }
    public GameObject skillObject { get; private set; }
    public Vector2 startingPosition { get; private set; }
    public Vector2 shotDirection { get; private set; }

    public Skill(int i, GameObject so, Vector2 sp)
    {
        index = i;
        skillObject = so;
        startingPosition = sp;
        shotDirection = new Vector2(1, 0);
    }
    
    public Skill(int i, GameObject so, Vector2 sp, Vector2 sd)
    {
        index = i;
        skillObject = so;
        startingPosition = sp;
        shotDirection = sd;
    }
}
