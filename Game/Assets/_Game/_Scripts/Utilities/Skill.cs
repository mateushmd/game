using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public string name { get; private set; }
    public int index { get; private set; }
    public Vector2 startingPosition { get; private set; }
    public ESightType sight { get; private set; }
    public Vector2 range { get; private set; }
    public float cooldownTime { get; }
    public Cooldown cooldown { get; }

    public Skill(string n, int i, Vector2 sp, float ct)
    {
        name = n;
        index = i;
        startingPosition = sp;
        sight = ESightType.Targeted;
        cooldownTime = ct;
        cooldown = new Cooldown();
    }
    
    public Skill(string n, int i, Vector2 sp, Vector2 sd, float ct)
    {
        name = n;
        index = i;
        startingPosition = sp;
        sight = ESightType.Targeted;
        cooldownTime = ct;
        cooldown = new Cooldown();
    }

    public Skill(string n, int i, ESightType sight, float ct)
    {
        name = n;
        index = i;
        startingPosition = new Vector2();
        this.sight = sight;
        cooldownTime = ct;
        cooldown = new Cooldown();
    }
    
    public Skill(string n, int i, ESightType sight, Vector2 range, float ct)
    {
        name = n;
        index = i;
        startingPosition = new Vector2();
        this.sight = sight;
        this.range = range;
        cooldownTime = ct;
        cooldown = new Cooldown();
    }
    
    public Skill(string n, int id, Vector2 sp, ESightType sig, Vector2 ran, float coolTime, Cooldown cool)
    {
        name = n;
        index = id;
        startingPosition = sp;
        sight = sig;
        range = ran;
        cooldownTime = coolTime;
        cooldown = cool;
    }
}
