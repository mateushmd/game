using System;
using _Game._Scripts.Damage;
using _Game._Scripts.Player;
using _Game._Scripts.Utilities;
using UnityEngine;

namespace _Game._Scripts.Skills
{
    public class FireBall : TriggerDamagePlayer
    {
        new void Awake()
        {
            baseDamage = 100;
            damageOnInt = 50;

            base.Awake();
            
            if(mov.right)
                GetComponent<Rigidbody2D>().velocity = new Vector2(5.2f, 0);
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(-5.2f, 0);
        }
    }
}
