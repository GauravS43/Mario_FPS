using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50;
    public void TakeDamage(float amount, GameObject explosion, RaycastHit hit)
    {
        health -= amount;
        if (health <= 0)
        {
            GameObject explosionGO = Instantiate(explosion, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(gameObject);
            Destroy(explosionGO, 2);
        }

    }
}
