using _Game._Scripts.Utilities;
using UnityEngine;

namespace _Game._Scripts.Damage
{
    public class Damageable : MonoBehaviour
    {
        /*void TakeDamage(int damage);
    event Action DamageEvent;*/
        private Stats st;
    
        private void Awake()
        {
            st = GetComponent<Stats>();
        }
    
        public void TakeDamage(int damage)
        {
            if (st.decreaseHP(damage))
            {
                Debug.Log("HP reduzido para: " + st.getHP());
            } else
            {
                Debug.Log("Parabens!!! Sua vida chegou a zero, entao o " + gameObject.name + " morreu");
            }
        }
    }
}
