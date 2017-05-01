using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class navigate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToMainMenu(){
		SceneManager.LoadScene("MainMenu");
	}

	public void GoToSelectScene(){
		SceneManager.LoadScene("SelectScene");
	}

	public void GoToStageScene(){
		SceneManager.LoadScene("StageScene");
	}

	public void StageToStageScene(){
		SceneManager.LoadScene("StageScene");
		SettingController.instance.GameIsOffTurnOnMusic();	
	}
}
