using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour {

    // Use this for initialization
     void Awake()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5.0f);
    }

    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.z < -15.0f)
        {
            Destroy(this.gameObject);
        }
	}
}
