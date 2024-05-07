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
    
        public void TakeDamage(float damageOnForce, float damageOnInt, EElement element, int bonus)
        {
            Random luck = new Random();
            int dodge = luck.Next(100);
            
            if(dodge >= st.agility)
            {
                float myForceDamage = damageOnForce - st.defense;
                float myMagicDamage = damageOnInt - st.magicDefense;
                float myDamage = damageOnInt + damageOnForce;
                myDamage *= bonus;
                switch (element)
                {
                    case EElement.Ar:
                        myDamage -= (st.windResistence + 100) / 100;
                        break;
                    case EElement.Agua:
                        myDamage -= (st.waterResistence + 100) / 100;
                        break;
                    case EElement.Terra:
                        myDamage -= (st.earthResistence + 100) / 100;
                        break;
                    case EElement.Fogo:
                        myDamage -= (st.fireResistence + 100) / 100;
                        break;
                }
                
                if (st.decreaseHP(myDamage))
                {
                    Debug.Log("HP reduzido para: " + st.HP);
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
