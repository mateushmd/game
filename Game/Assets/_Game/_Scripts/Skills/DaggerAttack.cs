using System.Collections;
using System.Collections.Generic;
using _Game._Scripts.Damage;
using UnityEngine;

public class DaggerAttack : TriggerDamagePlayer
{
    private Cooldown time = new Cooldown();

    private new void Awake()
    {
        Debug.Log(followPlayer);
        baseDamage = 25;
        damageOnForce = 7.5f;

        destroyOnHit = false;
        
        base.Awake();
        
        time.setTime(0.5f);
        time.StartCooldown();
        Debug.Log(followPlayer);
    }

    private void Update()
    {
        if (!time.isCoolingDown)
        {
            Destroy(gameObject);
        }
    }
}
