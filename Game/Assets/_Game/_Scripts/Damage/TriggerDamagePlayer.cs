using System;
using _Game._Scripts.Player;
using _Game._Scripts.Utilities;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using Stats = _Game._Scripts.Utilities.Stats;
using Base = _Game._Scripts.Skills.Base;

namespace _Game._Scripts.Damage
{
    public class TriggerDamagePlayer : MonoBehaviour
    {
        protected Stats stats;
        protected PlayerMovement mov;
        protected float damageOnForce = 0;
        protected float damageOnInt = 0;
        protected bool destroyOnHit = true;
        protected Vector2 initialPosition;
        protected EElement element = EElement.Neutro;
        
        protected void Awake()
        {
            stats = GetComponentInParent<Stats>();
            mov = GetComponentInParent<PlayerMovement>();
            damageOnForce = damageOnForce * stats.force / 100;
            damageOnInt = damageOnInt * stats.inteligence / 100;
            initialPosition = transform.position;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Damageable damageable = collision.GetComponent<Damageable>();
            if(damageable != null && collision.CompareTag("Enemy"))
            {
                int bonus = 0;
                
                switch (element)
                {
                    case EElement.Ar:
                        bonus = (stats.windBonus + 100) / 100;
                        break;
                    case EElement.Agua:
                        bonus = (stats.waterBonus + 100) / 100;
                        break;
                    case EElement.Terra:
                        bonus = (stats.earthBonus + 100) / 100;
                        break;
                    case EElement.Fogo:
                        bonus = (stats.fireBonus + 100) / 100;
                        break;
                }
                
                damageable.TakeDamage(damageOnForce, damageOnInt, element, bonus);
                if (destroyOnHit)
                    Destroy(gameObject);
            }
        }
    }
}
