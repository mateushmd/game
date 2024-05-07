using System.Collections;
using System.Collections.Generic;
using _Game._Scripts.Damage;
using UnityEngine;

public class StaffAttack : TriggerDamagePlayer
{
    new void Awake()
    {
        damageOnInt = 65;

        base.Awake();

        GetComponent<Rigidbody2D>().velocity = new Vector2(5.2f, 0);
    }
}
