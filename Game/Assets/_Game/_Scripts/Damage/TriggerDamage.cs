using UnityEngine;

namespace _Game._Scripts.Damage
{
    public class TriggerDamage : MonoBehaviour
    {
        [SerializeField] private float damage = 800;
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Damageable damageable = collision.GetComponent<Damageable>();
            if(damageable != null)
            {
                damageable.TakeDamage(damage);
            }
        }
    }
}
