using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnDamage : MonoBehaviour, IDamageble
{
    public void TakeDamage(int damage)
    {
        Debug.Log(gameObject.name + " foi atingido");
        DamageEvent.Invoke();
    }

    public event Action DamageEvent;
}
