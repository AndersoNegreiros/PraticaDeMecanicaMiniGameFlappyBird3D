using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Felpudo : MonoBehaviour {

    public GameObject cameraPrincipal;

    public AudioClip somBater;
    public AudioClip somPonto;
    public AudioClip somVoar;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider objeto)
    {
        if (objeto.gameObject.tag == "Finish")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 8.5f, -10.0f);
            GetComponent<Rigidbody>().AddTorque(new Vector3(-100.0f, -100.0f, -100.0f));

            cameraPrincipal.SendMessage("FimDeJogo");
            GetComponent<AudioSource>().PlayOneShot(somBater);
        }
        
    }

    private void OnTriggerExit(Collider objeto)
    {
        if(objeto.gameObject.tag == "GameController")
        {
            Destroy(objeto.gameObject);
            cameraPrincipal.SendMessage("MarcaPonto");
            GetComponent<AudioSource>().PlayOneShot(somPonto);
        }
    }

    void SomVoa()
    {
        GetComponent<AudioSource>().PlayOneShot(somVoar);
    }
}
