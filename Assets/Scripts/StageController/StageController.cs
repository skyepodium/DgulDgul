using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour {

	public bool[] levels;

	public Button[] levelButtons;

	public Text[] levelText;

	public Image[] lockIcons;

	public GameObject coinShopPanel;

	// Use this for initialization
	void Start () {
		InitializeStageMenu();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void InitializeStageMenu() {
		//scoreText.text = "" + GameManager.instance.highScore;
		//coinText.text = "" + GameManager.instance.coins;

		levels = GameManager.instance.stages;

		for(int i = 1; i< levels.Length; i++){
			if(levels[i]){
				lockIcons[i-1].gameObject.SetActive(false);
			}else{
				levelButtons[i-1].interactable =false;
				levelText[i-1].gameObject.SetActive(false);
			}
		}
	}

	public void LoadLevel() {
		if(GameManager.instance.isMusicOn){
			SettingController.instance.GameIsLoadedTrunOffMusic();
		}
		string level = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

		switch(level){

		case "Stage0":
		GameManager.instance.currentLevel = 0;
		break;

		case "Stage1":
		GameManager.instance.currentLevel = 1;
		break;
		
		
		}

		SceneManager.LoadScene(level);
	}

	public void OpenCoinShop() {
		coinShopPanel.SetActive(true);
	}

	public void CloseCoiShop() {
		coinShopPanel.SetActive(false);
	}

	public void GoToMainMenu() {
	}

	public void GoBackButton() {
	}
	
}
