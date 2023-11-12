using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Beams : NetworkBehaviour
{
    public Transform beamTransform;
    public LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer && Input.GetMouseButtonDown(0))
        {
            // want to fire
            CmdFire();
        }
    }

    [Command]
    public void CmdFire()
    {
        //raycast is done to show where the player hit
        Ray ray = new Ray(beamTransform.position, beamTransform.forward);
        if(Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            //darw the line when beam has hit object
            //check if player is hit.
            var player = hit.collider.gameObject.GetComponent<Beams>();
            if (player)
            {
                //it means it's a player so respawn them
                StartCoroutine(Respawn(hit.collider.gameObject));
            }

            RpcDrawBeam(beamTransform.position, hit.point);
        }
        else
        {
            RpcDrawBeam(beamTransform.position, beamTransform.position + beamTransform.forward * 100f);
        }
    }

    [Server]
    IEnumerator Respawn(GameObject go)
    {
        NetworkServer.UnSpawn(go);
        Transform newPos = NetworkManager.singleton.GetStartPosition();
        go.transform.position = newPos.position;
        go.transform.rotation = newPos.rotation;
        yield return new WaitForSeconds(1f);
        NetworkServer.Spawn(go, go);
    }

    [ClientRpc]
    void RpcDrawBeam(Vector3 start, Vector3 end)
    {
        //check if the beam flags the enumerator function
        StartCoroutine(BeamFlash(start, end));
    }

    IEnumerator BeamFlash(Vector3 start, Vector3 end)
    {
        line.SetPosition(0, start);
        line.SetPosition(1, end);
        yield return new WaitForSeconds(0.3f);
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, Vector3.zero);
    }
}
