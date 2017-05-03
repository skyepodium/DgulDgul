using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using UnityEngine.Collider2D;

public class GamePlayController : MonoBehaviour {
	//GamePlayController 인스턴스
	public static GamePlayController instance;

	public GameObject Character;

	public GameObject Goal;

	public Collider2D aa;

	//BG Bricks, 게임 시작후 생성됨
	[Serializable]
	private GameObject[] topandBottomBricks, leftBricks, rightBricks;

	//백그라운드 판넬, 레벨 끝냈을때, 플레이어 죽었을때, 멈췄을때
	private GameObject panelBG, levelFinishedPanel, playerDiedPanel, pausePanel;

	//게임에서 생성되는 모든 브릭 참조
	private GameObject topBrick, bottomBrick, leftBrick, rightBrick;

	//BG bricks의 위치에 사용된다.
	private Vector3 coordinates;

	//캐릭터에 대한 레퍼런스 왜냐하면, GamePlayController 는 유저가 선택한 캐릭터를 초기화한다. 
	[Serializable]
	private GameObject[] players;

	//게임의 레벨타임
	public float levelTime;

	//텍스트에 대한 레퍼런스, 목숨(생명), 점수, 레벨시간, 레벨끝에 점수 보여줌, 카운트다운그리고레벨시작, 비디오 보기
	public Text liveText, scoreText, levelTimeText, showScoreAtTheEndOfLevelText, countDownAndBeginLevelText, watchVideoText;

	//레벨 시작전 카운트 다운
	public float countDownBeforeLevelBegins = 3.0f;

	//작은 공 카운트, 모든 작은공들은 레벨이 끝났을때 죽는다.
	public static int smallBallsCount = 0;

	//플레이어 목숨, 플레이어 점수, 코인들
	public int playerLives, playerScore, coins;

	//레벨을 카운트하기 위한 게임이 멈췄는지, 레벨이 시작되는지, 레벨이 진행중인지를 알기위한 불린 값, 
	private bool isGamePaused, hasLevelBegan, levelInProgress, countdownLevel;

	//레벨이 끝난 후 아이템이 생성되고, 레벨이 끝난 후 유저는 수집할 수 있다. 
	[Serializable]
	private GameObject[] endOfLevelRewards;

	void Awake () {
		createInstance();

	}

	void Start () {
		InitializeGamePlayController();
	}
	
	// Update is called once per frame
	void Update () {

		pdateGamePlayController();
	}

	void CreateInstance() {

		if (instance == null){
			instance = this;
		}

	}

	void InitializeGamePlayController() {

		if(GameManager.instance.isGameStartedFromLevelMenu) {
			playerScore = 0;
			playerLives = 2;
			GameManager.instance.currentScore = playerScore;
			GameManager.instance.currentLives = playerLives;
			GameManager.instance.isGameStartedFromLevelMenu = false;
		}else{
			playerScore = GameManager.instance.currentScore;
			playerLives = GameManager.instance.currentLives;
		}

		levelTimerText.text = levelTime.ToString("F0");
		scoreText.text = "Score x" + playerScore;
		liveText.text = "x" + playerLives;

		Time.timeScale = 0;
		countDownAndBeginLevelText.text = countDownBeforeLevelBegins.ToString("F0");
	}

	void UpdateGamePlayController() {
		scoreText.text = "Score x" + playerScore;

		if (hasLevelBegan) {
			CountdownAndBeginLevel();
		}
	}

	public void setHasLevelBegan(bool hasLevelBegan) {
		this.hasLevelBegan = hasLevelBegan;
	}

	void CountdownAndBeginLevel() {
		countDownBeforeLevelBegins -= (0.19 * 0.15f);
		countDownAndBeginLevelText = countDownBeforeLevelBegins.ToString ("F0");
		if(countDownBeforeLevelBegins <= 0){
			Time.timeScale = 1;
			hasLevelBegan = false;
			levelInProgress = true;
			countdownLevel = true;
			countDownAndBeginLevelText.gameObject.SetActive(false);
		}
	}

	public void end_Event() {

		Debug.Log("충돌했습니다.");
		
	}

}
