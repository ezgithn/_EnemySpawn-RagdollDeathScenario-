using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDamageExecutor : MonoBehaviour
{
    public static void TakeDamage(IDamageable damageable, float damage)
    {
        damageable.TakeDamage(damage);
    }
}
