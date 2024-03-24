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
    public float cooldownTime { get; }
    public Cooldown cooldown { get; }

    public Skill(int i, GameObject so, Vector2 sp, float ct)
    {
        index = i;
        skillObject = so;
        startingPosition = sp;
        sight = ESightType.Targeted;
        cooldownTime = ct;
        cooldown = new Cooldown();
    }
    
    public Skill(int i, GameObject so, Vector2 sp, Vector2 sd, float ct)
    {
        index = i;
        skillObject = so;
        startingPosition = sp;
        sight = ESightType.Targeted;
        cooldownTime = ct;
        cooldown = new Cooldown();
    }

    public Skill(int i, GameObject so, ESightType sight, float ct)
    {
        index = i;
        skillObject = so;
        startingPosition = new Vector2();
        this.sight = sight;
        cooldownTime = ct;
        cooldown = new Cooldown();
    }
    
    public Skill(int i, GameObject so, ESightType sight, Vector2 range, float ct)
    {
        index = i;
        skillObject = so;
        startingPosition = new Vector2();
        this.sight = sight;
        this.range = range;
        cooldownTime = ct;
        cooldown = new Cooldown();
    }
}
