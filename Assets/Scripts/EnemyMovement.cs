using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float lookRadius = 90;
    public Transform target;
    public float height;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            transform.LookAt(target);
            transform.position = Vector3.Lerp(transform.position, target.position, 0.01f);
        }

        if (target.position.y != height)
        {
            transform.position.Set(transform.position.x, height, transform.position.z);
        }
    }
}
