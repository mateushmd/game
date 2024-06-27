using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Runtime.Serialization;
using System.Text;
using _Game._Scripts.Utilities;
using _Game.Data;
using Newtonsoft.Json;
using Unity.VisualScripting;


public class Equipment : MonoBehaviour
{
    public string weapon { get; private set; }
    
    void Start()
    {
        weapon = "Sword";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void saveData()
    {
        DataControl.saveEquipment(this);
    }

    public void getOnData()
    {
        Equipment eq = DataControl.getEquipmentOnData();
        if(eq.weapon == null)
            eq.switchWeapon("Sword");
        weapon = eq.weapon;
    }

    public void switchWeapon(string weapon)
    {
        if (weapon != null && !weapon.Equals(""))
        {
            this.weapon = weapon;
        }
    }
}
