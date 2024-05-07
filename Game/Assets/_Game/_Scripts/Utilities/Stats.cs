using System.Collections.Generic;
using _Game._Scripts.Damage;
using UnityEngine;

namespace _Game._Scripts.Utilities
{
    [RequireComponent(typeof(Damageable))]
    public class Stats : MonoBehaviour
    {
        //Stats base
        public float HP { get; private set;  }
        public float MP { get; private set; }
        public float maxHP { get; private set; } //statID 1
        public float maxMP { get; private set; } //statID 2
        public int inteligence { get; private set; } //statID 3
        public int force { get; private set; } //statID 4
        public int dexterity { get; private set; } //statID 5
        public int agility { get; private set; } //statID 6
        public int defense { get; private set; } //statID 7
        public int magicDefense { get; private set; }
        
        //Stats %
        public int windResistence { get; private set; }
        public int waterResistence { get; private set; }
        public int earthResistence { get; private set; }
        public int fireResistence { get; private set; }
        public int windBonus { get; private set; }
        public int waterBonus { get; private set; }
        public int earthBonus { get; private set; }
        public int fireBonus { get; private set; }
        
        [Header("(De)buffs")] 
        private List<State> buffs = new List<State>();

        public void HPRecover(float value)
        {
            if (maxHP >= (HP + value))
                HP = maxHP;
            else HP += value;
        }

        public void MPRecover(float value)
        {
            if (maxMP >= (MP + value))
                MP = maxMP;
            else MP += value;
        }

        public bool decreaseHP(float value)
        {
            if (0 >= (HP - value))
            {
                return false; //Morte
            }

            HP -= value;
            return true; //Ainda possui HP
        }

        public bool decreaseMP(float value)
        {
            if (0 > (MP - value))
            {
                return false; //Negar ação com uso de MP
            }

            MP -= value;
            return true; //Permitir ação com uso de MP
        }

        public void buffMaxHP(string name, int value, float time)
        {
            if (time != 0)
                buffs.Add(new State(1, name, value, time));
            maxHP += value;
        }

        public void buffMaxMP(string name, int value, float time)
        {
            if (time != 0)
                buffs.Add(new State(2, name, value, time));
            maxMP += value;
        }

        public void buffInteligence(string name, int value, float time)
        {
            if (time != 0)
                buffs.Add(new State(3, name, value, time));
            inteligence += value;
        }

        public void buffForce(string name, int value, float time)
        {
            if (time != 0)
                buffs.Add(new State(4, name, value, time));
            force += value;
        }

        public void buffDexterity(string name, int value, float time)
        {
            if (time != 0)
                buffs.Add(new State(5, name, value, time));
            dexterity += value;
        }

        public void buffAgility(string name, int value, float time)
        {
            if (time != 0)
                buffs.Add(new State(6, name, value, time));
            agility += value;
        }

        public void buffDefense(string nome, int value, float time)
        {
            if (time != 0)
                buffs.Add(new State(7, name, value, time));
            defense += value;
        }

        private void Awake()
        {
            HP = maxHP;
            MP = maxMP;
        }

        // Update is called once per frame
        void Update()
        {
            foreach (State st in buffs)
            {
                if (st.timeEnd())
                {
                    Debug.Log("State deletado: " + st.name);
                    adjust(st.statID, st.value);
                    buffs.Remove(st);
                }
            }
        }

        private void adjust(int statID, int value)
        {
            switch (statID)
            {
                case 1:
                    maxHP -= value;
                    break;
                case 2:
                    maxMP -= value;
                    break;
                case 3:
                    inteligence -= value;
                    break;
                case 4:
                    force -= value;
                    break;
                case 5:
                    dexterity -= value;
                    break;
                case 6:
                    agility -= value;
                    break;
                case 7:
                    defense -= value;
                    break;
            }
        }

        public List<State> getAllStates()
        {
            return buffs;
        }

        public List<State> getBuff()
        {
            List<State> st = new List<State>();
            foreach (State str in buffs)
            {
                if (str.value > 0)
                    st.Add(str);
            }

            return st;
        }

        public List<State> getDebuff()
        {
            List<State> st = new List<State>();
            foreach (State str in buffs)
            {
                if (str.value < 0)
                    st.Add(str);
            }

            return st;
        }

        public State getStateByName(string name)
        {
            foreach (State st in buffs)
            {
                if (st.name.Equals(name))
                {
                    return st;
                }
            }

            return null;
        }
    }
}