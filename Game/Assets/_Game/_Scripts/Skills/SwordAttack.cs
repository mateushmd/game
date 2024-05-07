using System;
using System.Collections;
using System.Collections.Generic;
using _Game._Scripts.Damage;
using UnityEngine;

public class SwordAttack : TriggerDamagePlayer
{
    private Cooldown time = new Cooldown(); 

    private new void Awake()
    {
        damageOnForce = 65;

        destroyOnHit = false;
        
        base.Awake();
        
        time.setTime(0.5f);
        time.StartCooldown();
    }

    private void Update()
    {
        if (!time.isCoolingDown)
        {
            Destroy(gameObject);
        }
    }
}
