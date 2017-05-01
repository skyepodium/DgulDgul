using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyblock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnMouseDown() {
		Destroy(this.gameObject);
	}
}
