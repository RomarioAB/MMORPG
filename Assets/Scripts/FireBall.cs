using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mirror;

public class FireBall : NetworkBehaviour
{
    public GameObject fireballPrefab;
    public Transform fireballSpawn;

    
    void Update()
    {
        if (isLocalPlayer && Input.GetMouseButtonDown(0))
        {
            CmdFire();
        }
    }

    [Command]
    void CmdFire()
    {
        //Create the fireball from the prefab
        GameObject fireball = (GameObject)Instantiate(fireballPrefab, fireballSpawn.position, fireballSpawn.rotation);

        //Add velocity to the fireball 
        fireball.GetComponent<Rigidbody>().velocity = fireball.transform.forward * 6.0f;

        //Spawn the fireball on the client 
        NetworkServer.Spawn(fireball);

        //Destroy the fireball after 2 seconds
        Destroy(fireball, 2);
    }
}
