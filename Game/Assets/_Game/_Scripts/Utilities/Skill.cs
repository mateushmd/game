using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public int index { get; private set; }
    public GameObject skillObject { get; private set; }
    public Vector2 startingPosition { get; private set; }
    public ESightType sight { get; private set; }
    public Vector2 range { get; private set; }

    public Skill(int i, GameObject so, Vector2 sp)
    {
        index = i;
        skillObject = so;
        startingPosition = sp;
        sight = ESightType.Targeted;
    }
    
    public Skill(int i, GameObject so, Vector2 sp, Vector2 sd)
    {
        index = i;
        skillObject = so;
        startingPosition = sp;
        sight = ESightType.Targeted;
    }

    public Skill(int i, GameObject so, ESightType sight)
    {
        index = i;
        skillObject = so;
        startingPosition = new Vector2();
        this.sight = sight;
    }
    
    public Skill(int i, GameObject so, ESightType sight, Vector2 range)
    {
        index = i;
        skillObject = so;
        startingPosition = new Vector2();
        this.sight = sight;
        this.range = range;
    }
}
