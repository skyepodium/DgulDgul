using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Collider2D;

public class GamePlayController : MonoBehaviour {

	public GameObject Character;

	public GameObject Goal;

	public Collider2D aa;



	public static GamePlayController instance;

	void Awake () {

		if (GamePlayController.instance == null){
			GamePlayController.instance = this;
		}

	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void end_Event() {
		Debug.Log("충돌했습니다.");
	}

}
