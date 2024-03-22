using System;
using _Game._Scripts.Utilities;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using Stats = _Game._Scripts.Utilities.Stats;
using Base = _Game._Scripts.Skills.Base;

namespace _Game._Scripts.Damage
{
    public class TriggerDamagePlayer : MonoBehaviour
    {
        //Em porcentagem
        protected float baseDamage = 0;
        protected float damageOnForce = 0;
        protected float damageOnInt = 0;
        protected float duration;
        protected bool destroyOnHit = true;
        protected float totalDamage = 0;
        private Stats stats;
        
        protected void Awake()
        {
            stats = GetComponentInParent<Stats>();
            damageOnForce = damageOnForce * stats.getForce() / 100;
            damageOnInt = damageOnInt * stats.getInteligence() / 100;
            totalDamage = baseDamage + damageOnInt + damageOnForce;
        }

        private void Update()
        {
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
