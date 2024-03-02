using System;
using _Game._Scripts.Utilities;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using Stats = _Game._Scripts.Utilities.Stats;

namespace _Game._Scripts.Damage
{
    public class TriggerDamage : MonoBehaviour
    {
        //Em porcentagem
        [SerializeField] private float damageOnForce;
        [SerializeField] private float damageOnInt;
        [SerializeField] private float duration;
        [SerializeField] private bool destroyOnHit;
        private float totalDamage = 0;
        private Stats stats;
        
        private void Awake()
        {
            stats = GetComponentInParent<Stats>();
            damageOnForce *= stats.getForce();
            damageOnInt *= stats.getInteligence();
            totalDamage = damageOnInt + damageOnForce;
        }

        private void Update()
        {
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Damageable damageable = collision.GetComponent<Damageable>();
            if(damageable != null)
            {
                damageable.TakeDamage(totalDamage);
                if (destroyOnHit)
                    Destroy(gameObject);
            }
        }
    }
}
