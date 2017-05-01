using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class col : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		Destroy(col.gameObject);
	}

		void OnTriggerEnter2D( Collider2D col){

		if ( col.gameObject.tag == "Player" ){
			Destroy(col.gameObject);
		}
	}
}
