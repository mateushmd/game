using UnityEngine;

namespace _Game._Scripts.Damage
{
    public class TriggerDamage : MonoBehaviour
    {
        [SerializeField] private int damage = 10;
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Trigger ativado: " + collision.name);
            Damageable damageable = collision.GetComponent<Damageable>();
            if(damageable != null)
            {
                damageable.TakeDamage(damage);
                Debug.Log("O objeto atinjido possui um IDamageable");
            }
        }
    }
}
