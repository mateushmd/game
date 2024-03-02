using System;
using _Game._Scripts.Utilities;
using UnityEngine;
using Random = System.Random;

namespace _Game._Scripts.Damage
{
    public class Damageable : MonoBehaviour
    {
        private Stats st;
    
        private void Awake()
        {
            st = GetComponent<Stats>();
        }
    
        public void TakeDamage(float damage)
        {
            Random luck = new Random();
            int dodge = luck.Next(100);
            
            if(dodge >= st.getAgility())
            {
                float myDamage = damage - st.getDefense();
                
                if (st.decreaseHP(myDamage))
                {
                    Debug.Log("HP reduzido para: " + st.getHP());
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.Log("Desviou do ataque");
            }
        }
    }
}
