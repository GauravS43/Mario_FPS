using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchGun : MonoBehaviour
{
    public MeshRenderer pistol;
    public MeshRenderer shotgun;
    public GunScript pistolScript;
    public GunScript shotgunScript;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pistol.enabled = true;
            pistolScript.enabled = true;
            shotgun.enabled = false;
            shotgunScript.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pistol.enabled = false;
            pistolScript.enabled = false;
            shotgun.enabled = true;
            shotgunScript.enabled = true;
        }
    }
}
