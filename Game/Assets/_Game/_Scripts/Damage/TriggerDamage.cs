using System;
using _Game._Scripts.Utilities;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using Stats = _Game._Scripts.Utilities.Stats;

namespace _Game._Scripts.Damage
{
    public class TriggerDamage : MonoBehaviour
    {
        private float damageOnForce = 150;
        private float damageOnInt = 20;
        private float totalDamage = 0;
        private Stats stats;
        
        private void Awake()
        {
            stats = GetComponentInParent<Stats>();
        }

        private void Update()
        {
            damageOnForce += stats.getForce();
            damageOnInt += stats.getInteligence();
            totalDamage = damageOnInt + damageOnForce;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Damageable damageable = collision.GetComponent<Damageable>();
            if(damageable != null)
            {
                damageable.TakeDamage(totalDamage);
            }
        }
    }
}
