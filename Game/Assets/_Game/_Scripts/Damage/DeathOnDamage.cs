using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnDamage : MonoBehaviour, IDamageble
{
    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
    }
}
