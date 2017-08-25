using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{

    public float timePerScan = 2.5f;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Scan", 0, timePerScan);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Scan()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 100);
        Vector3 characterToCollider;
        float dot;
        foreach (Collider2D collider in cols)
        {
            characterToCollider = (collider.transform.position - transform.position).normalized;
            dot = Vector3.Dot(characterToCollider, transform.forward);
            if (dot >= Mathf.Cos(55))
            {
                if (collider.tag == "Enemy")
                {
                    collider.gameObject.GetComponent<MeshRenderer>().enabled = true;
                }
            }
            else
            {
                //objectSpotted = false;
            }
        }
    }
}
