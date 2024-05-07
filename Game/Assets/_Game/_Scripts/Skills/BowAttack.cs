using System.Collections;
using System.Collections.Generic;
using _Game._Scripts.Damage;
using UnityEngine;

public class BowAttack : TriggerDamagePlayer
{
    new void Awake()
    {
        damageOnForce = 50;

        base.Awake();

        GetComponent<Rigidbody2D>().velocity = new Vector2(5.2f, 0);
    }
}
