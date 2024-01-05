using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float maxHP; //statID 1
    [SerializeField] private float maxMP; //statID 2
    [SerializeField] private int inteligence; //statID 3
    [SerializeField] private int force; //statID 4
    [SerializeField] private int dexterity; //statID 5
    [SerializeField] private int agility; //statID 6

    [Header("(De)buffs")] 
    private List<State> buffs = new List<State>();
    
    public void buffMaxHP(string name, int value,  float time)
    {
        if(time != 0)
            buffs.Add(new State(1, name, value, time));
        maxHP += value;
    }
    
    public void buffMaxMP(string name, int value,  float time)
    {
        if(time != 0)
            buffs.Add(new State(2, name, value, time));
        maxMP += value;
    }
    
    public void buffInteligence(string name, int value,  float time)
    {
        if(time != 0)
            buffs.Add(new State(3, name, value, time));
        inteligence += value;
    }

    public void buffForce(string name, int value, float time)
    {
        if(time != 0)
            buffs.Add(new State(4, name, value, time));
        force += value;
    }
    
    public void buffDexterity(string name, int value,  float time)
    {
        if(time != 0)
            buffs.Add(new State(5, name, value, time));
        dexterity += value;
    }
    
    public void buffAgility(string name, int value,  float time)
    {
        if(time != 0)
            buffs.Add(new State(6, name, value, time));
        agility += value;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
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
            if(str.value > 0)
                st.Add(str);
        }

        return st;
    }
    
    public List<State> getDebuff()
    {
        List<State> st = new List<State>();
        foreach (State str in buffs)
        {
            if(str.value < 0)
                st.Add(str);
        }

        return st;
    }
}

public class State
{
    private Cooldown cooldown = new Cooldown();
    public string name;
    public int statID;
    public int value;

    public State(int statID, string name, int value, float time)
    {
        this.statID = statID;
        this.name = name;
        this.value = value;
        
        this.cooldown.setTime(time);
        this.cooldown.StartCooldown();
    }

    public bool timeEnd()
    {
        return !cooldown.isCoolingDown;
    }
}
