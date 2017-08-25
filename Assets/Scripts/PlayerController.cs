using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public Vector3 Direction;

	// Use this for initialization
	void Start () {
        		
	}
	
	// Update is called once per frame
	void Update () {
	    if (!isLocalPlayer)
	    {
	        return;
	    }

        var rotation = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
	    var movement = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

	    transform.Rotate(0, 0, -rotation);
	    transform.Translate(0, movement, 0);
    }

    public override void OnStartLocalPlayer()
    {
        foreach (MeshRenderer mesh in GetComponentsInChildren<MeshRenderer>())
        {
            mesh.material.color = Color.blue;
        }
    }
}
