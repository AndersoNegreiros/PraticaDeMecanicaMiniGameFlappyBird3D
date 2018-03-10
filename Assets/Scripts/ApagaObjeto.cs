using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagaObjeto : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("DestroiObjetos", 1);
	}
	
	// Update is called once per frame
	void DestroiObjetos () {
        Destroy(this.gameObject);

    }
}
