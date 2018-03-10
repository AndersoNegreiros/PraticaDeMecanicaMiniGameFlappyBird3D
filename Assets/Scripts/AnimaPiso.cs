using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaPiso : MonoBehaviour {

    public Material materialPiso;
    private float velAniPiso = 0.75f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float offset = Time.time * velAniPiso;
        materialPiso.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
