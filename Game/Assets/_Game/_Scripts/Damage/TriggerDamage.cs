using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger ativado: " + collision.name);
        IDamageble damageable = collision.GetComponent<IDamageble>();
        if(damageable != null)
            damageable.TakeDamage(damage);
    }
}
