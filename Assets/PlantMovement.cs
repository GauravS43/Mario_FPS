using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantMovement : MonoBehaviour
{
    public Transform plant;
    public Transform pipe;
    public int height;

    public bool goingUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempPos = plant.position;

        if (goingUp && plant.position.y < pipe.position.y + height)
        {
            tempPos.y += 0.05f;
            plant.position = tempPos;
        }
        else
        {
            goingUp = false;
        }

        if (!goingUp && plant.position.y > pipe.position.y - height)
        {
            tempPos.y -= 0.05f;
            plant.position = tempPos;
        }
        else
        {
            goingUp = true;
        }
    }
}
