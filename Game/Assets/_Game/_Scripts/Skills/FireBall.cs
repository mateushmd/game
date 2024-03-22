using System;
using _Game._Scripts.Damage;
using UnityEngine;

namespace _Game._Scripts.Skills
{
    public class FireBall : TriggerDamagePlayer
    {

        void Awake()
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
                if (destroyOnHit)
                    Destroy(gameObject);
            }
        }
    }
}
