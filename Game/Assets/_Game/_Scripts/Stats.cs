using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float maxHP;
    [SerializeField] private float maxMP;
    [SerializeField] private int inteligence;
    [SerializeField] private int force;
    [SerializeField] private int dexterity;
    [SerializeField] private int agility;

    [Header("(De)buffs")] 
    private List<State> buffs = new List<State>();

    public void buffForce(string name, int value, float time)
    {
        buffs.Add(new State(4, name, value, time));
        force += value;
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
