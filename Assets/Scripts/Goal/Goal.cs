using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D( Collider2D col){

		if ( col.gameObject.tag == "Player" ){

			Destroy(col.gameObject);
			GamePlayController.instance.end_Event();
			//충돌하면 GamePlayController의 end_Event함수를 호출한다.
		}
	}	
}
