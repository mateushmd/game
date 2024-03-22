using System;
using _Game._Scripts.Damage;
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

            GetComponent<Rigidbody2D>().velocity = new Vector2(5.2f, 0);
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Damageable damageable = collision.GetComponent<Damageable>();
            if(damageable != null && collision.CompareTag("Enemy"))
            {
                damageable.TakeDamage(totalDamage);
                collision.GetComponent<Stats>().buffAgility("fireball", -4, 1.5f);
                if (destroyOnHit)
                    Destroy(gameObject);
            }
        }
    }
}
