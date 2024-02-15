using System;
using _Game._Scripts.Utilities;
using UnityEngine;
using Random = System.Random;

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
    
        public void TakeDamage(float damage)
        {
            Random luck = new Random();
            //randNum.Next(150)
            int dodge = luck.Next(100);
            Debug.Log("Sorte obtida: " + dodge);
            
            if(dodge >= st.getAgility())
            {
                float myDamage = damage - st.getDefense();

                if (st.decreaseHP(damage))
                {
                    Debug.Log("HP reduzido para: " + st.getHP());
                }
                else
                {
                    Debug.Log("Parabens!!! Sua vida chegou a zero, entao o " + gameObject.name + " morreu");
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
