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

		case "Stage2":
		GameManager.instance.currentLevel = 2;
		break;

		case "Stage3":
		GameManager.instance.currentLevel = 3;
		break;

		case "Stage4":
		GameManager.instance.currentLevel = 4;
		break;

		case "Stage5":
		GameManager.instance.currentLevel = 5;
		break;

		case "Stage6":
		GameManager.instance.currentLevel = 6;
		break;

		case "Stage7":
		GameManager.instance.currentLevel = 7;
		break;

		case "Stage8":
		GameManager.instance.currentLevel = 8;
		break;

		case "Stage9":
		GameManager.instance.currentLevel = 9;
		break;

		case "Stage10":
		GameManager.instance.currentLevel = 10;
		break;

		case "Stage11":
		GameManager.instance.currentLevel = 11;
		break;
		
		case "Stage12":
		GameManager.instance.currentLevel = 12;
		break;

		case "Stage13":
		GameManager.instance.currentLevel = 13;
		break;

		case "Stage14":
		GameManager.instance.currentLevel = 14;
		break;

		case "Stage15":
		GameManager.instance.currentLevel = 15;
		break;

		case "Stage16":
		GameManager.instance.currentLevel = 16;
		break;

		case "Stage17":
		GameManager.instance.currentLevel = 17;
		break;

		case "Stage18":
		GameManager.instance.currentLevel = 18;
		break;

		case "Stage19":
		GameManager.instance.currentLevel = 19;
		break;

		case "Stage20":
		GameManager.instance.currentLevel = 20;
		break;

		case "Stage21":
		GameManager.instance.currentLevel = 21;
		break;

		case "Stage22":
		GameManager.instance.currentLevel = 22;
		break;

		case "Stage23":
		GameManager.instance.currentLevel = 23;
		break;

		case "Stage24":
		GameManager.instance.currentLevel = 24;
		break;

		case "Stage25":
		GameManager.instance.currentLevel = 25;
		break;

		case "Stage26":
		GameManager.instance.currentLevel = 26;
		break;

		case "Stage27":
		GameManager.instance.currentLevel = 27;
		break;

		case "Stage28":
		GameManager.instance.currentLevel = 28;
		break;

		case "Stage29":
		GameManager.instance.currentLevel = 29;
		break;

		case "Stage30":
		GameManager.instance.currentLevel = 30;
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
