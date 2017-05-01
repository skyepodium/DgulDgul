using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	private GameData data;
	//아래 만든 클래스 변수를 담는다.

	public int currentLevel;
	//현재 레벨이 어디인지를 지시한다.

	public int currentScore;
	//현재 점수를 추적한다. 

	public bool isGameStartedFirstTime;

	public bool isMusicOn;

	public int selectedPlayer;
	//public int selectedWeapon;
	public int coins;
	public int highScore;

	public bool[] players;
	public bool[] stages;
	//public bool[] weapons;
	public bool[] achievements;
	//public bool[] collectedItems;

	void Awake(){
		MakeSingleton();
		InitializeGameVariables();
	}

	// Use this for initialization
	void Start () {
	}

	//게임매니저가 각 씬에 위치해야한다. 현재 메인메뉴에만 위치한다. 이를 위해 싱글톤이 필요하다.
	//MakeSingleton함수를 통해 메인 메뉴의 게임 매니저가 다른 씬에서도 보존된다.
	//만약 유니티로 다른 씬을 실행히기면 게임매니저가 존재하지 않는다.
	void MakeSingleton(){//게임오브젝트가 씬에 씬에 있을경우
		if(instance != null){
			Destroy(gameObject);//만약여기서 게임매니저를 제거하지 않으면 메인메뉴로 갔을때 게임 매니저가 2개 존재하게된다.
		}else{//게임 오브젝트가 씬에 없을 경우
			instance = this;
			DontDestroyOnLoad(gameObject);//씬에서 씬으로 이동할때 게임매니저를 보존한다.
		}
	}
	

	void InitializeGameVariables() {//게임 변수를 초기화하는 함수, 위에 선언던 모든 변수를 초기화한다.

		Load();//아래 Load함수 실행

		if(data != null){
			isGameStartedFirstTime = data.getIsGameStartedFirstTime();
		}else{
			isGameStartedFirstTime = true;
		}
		if(isGameStartedFirstTime){//게임이 처음으로 시작되었을때 모든 변수를 초기화한다. if문에서 isGameStartedFirstTime이 true일때만 실행된다.

			highScore = 0;
			coins = 0;

			selectedPlayer = 0;

			isGameStartedFirstTime = false;//게임을 한번 실행했으므로 isGameStartedFirstTime에 false를 넣는다.
			isMusicOn = true;//게임 실행했을때 음악을 자동으로 재생한다.

			players = new bool[6];
			stages = new bool[40];
			achievements = new bool[8];

			players[0] = true;//첫번째 플레이어는 열려있다.(unlock)
			for(int i=1; i<players.Length; i++){//for문에서 이미 0이 열려있기 때문에 1부터 시작한다.
				players [i] = false;//첫번째를 제외한 다른 캐릭터는 잠근다.
			}

			stages[0] = true;//첫번째 스테이지는 열려있다. (unlock)
			for(int i=1; i<stages.Length; i++){//for문에서 이미 0이 열려있기 때문에 1부터 시작한다.
				stages [i] = false;//첫번째를 제외한 다른 스테이지는 잠근다.
			}

			for(int i=0; i<achievements.Length; i++){
				achievements[i] = false;
			}

			data = new GameData();//데이터의 새로운 인스턴스를 만든다. 위에서 처음 실행했을때 데이터를 0등으로 초기화하는데 저장하지는 않았다. setter를 통해 데이터 저장

			data.setHighScore (highScore);
			data.setCoins (coins);
			data.setSelectedPlayer (selectedPlayer);
			data.setIsGameStartedFirstTime (isGameStartedFirstTime);
			data.setIsMusicOn (isMusicOn);
			data.setPlayers (players);
			data.setStages (stages);
			data.setAchievements (achievements);

			Save();//Save함수를 통해 파일에 데이터 저장

			Load();//바로 로드함수 실행, 이유:데이터를 사용하기 위함
		}/*else{//이미 게임이 플레이 되었을때 게임 데이터를 로드한다.

			highScore = data.getHighScore();
			coins = data.getCoins();
			selectedPlayer = data.getSelectedPlayer();
			isGameStartedfirstTime = data.getIsGameStartedFirstTime();
			isMusicOn = data.getIsMusicOn();
			players = data.getPlayers();
			stages = data.getStages();
			achievements = data.getAchievements();
		}
*/
	}

	public void Save() {//파일에 데이터를 저장한다.

		FileStream file = null;//파일스트림 변수 file선언하고 null로 초기화

		try{//파일을 열었는데 없으면 exception에서 catch에서 잡는다.

			BinaryFormatter bf = new BinaryFormatter();

			file = File.Create(Application.persistentDataPath + "/GameData.dat");
			//파일이 저장되는 경로 
			if(data != null){
				//data는 위에서 publicd GameData로 선언한 변수
				//데이터가 null이 아니면 set함수를 통해 변수에 값을 저장한다.
				//들어가는 값은 위에서 public으로 선언한 변수
				data.setHighScore(highScore);
				data.setCoins(coins);
				data.setIsGameStartedFirstTime(isGameStartedFirstTime);
				data.setPlayers(players);
				data.setStages(stages);
				data.setSelectedPlayer(selectedPlayer);
				data.setIsMusicOn(isMusicOn);
				data.setAchievements(achievements);

				bf.Serialize(file, data);
				//파일에 데이터를 저장한다.
			}

		}catch(Exception e){

		}finally{//finally에서 닫힌다. 무엇이 일어나든지 간에 1. 데이터가 없으면 위에서 settter함수가 실행되지 않는다.setter는 값을 변수에 저장하기 위한 함수
			if(file != null){//파일이 없으면 입출력을 닫는다.
				file.Close();
			}
		}

	}

	public void Load(){//파일에 있는 데이터를 로드한다.

		FileStream file = null;

		try{

			BinaryFormatter bf = new BinaryFormatter();

			file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);

			data = (GameData)bf.Deserialize(file);
			//어떤데이터가 얻어지는지 모른다. 그래서 앞에 데이터가 GameData임을 명시한다. (GameData)를 cast라 부른다.

		}catch(Exception e){

		}finally{
			if(file != null){
				file.Close();
			}
		}
	}
}

[Serializable]//1. 직렬화할 수 있는 클래스로 만든다. 2. 직렬화를 하지 않으면 이 클래스를 바이너리 입출력으로 저장할 수 없다.
class GameData {

	private bool isGameStartedFirstTime;
	//이 변수는 초기화를 위해 사용된다.
	//유저가 처음으로 설치했을때 true이며 게임을 시작하면  false가 되고, 모든 변수를 초기화한다.

	private bool isMusicOn;
	//음악 들리는지 추적
	//게임을 꺼도 저장된다.

	private int selectedPlayer;
	//어떤 플레이어(캐릭터)가 선택되는지를 알 수 있다.
	//게임을 꺼도 저장된다.

	//private int selectedWeapon; 무기필요없음

	private int coins;
	private int highScore;
	//사용자가 가진 코인과, 높은 점수 추적

	private bool[] players;
	//어떤 캐릭터가 잠겨있인지 열려있는지 추적
	private bool[] stages;
	//어떤 스테이지가 잠겨있는지 열려있는지 추적

	//private bool[] weapons; 무기필요없음

	private bool[] achievements;

	//private bool[] collectedItems;
	//레벨을 완료하면 아이템을 준다.

	//아래 set,get설명
	//기본적으로 setter, getter라고 부른다.
	//변수에 바로 접근하는 것이 아닌, 함수를 통해 변수에 값을 넣고, 변수의 값을 불러낸다.
	//setter는 변수에 값을 넣는다.
	//getter는 return을 통해 변수의 값을 불러낸다.


	public void setIsGameStartedFirstTime(bool isGameStartedFirsTime){
		this.isGameStartedFirstTime = isGameStartedFirstTime;
	}

	public bool getIsGameStartedFirstTime(){
		return this.isGameStartedFirstTime;
	}

	public void setIsMusicOn(bool isMusicOn){
		this.isMusicOn = isMusicOn;
	}

	public bool getIsMusicOn(){
		return this.isMusicOn;
	}

	public void setSelectedPlayer(int selectedPlayer){
		this.selectedPlayer = selectedPlayer;
	}

	public int getSelectedPlayer(){
		return this.selectedPlayer;
	}

	public void setCoins(int coins){
		this.coins = coins;
	}

	public int getCoins(){
		return this.coins;
	}
	
	public void setHighScore(int highScore){
		this.highScore = highScore;
	}

	public int getHighScore(){
		return this.highScore;
	}

	public void setPlayers(bool[] players){
		this.players = players;
	}

	public bool[] getPlayers(){
		return this.players;
	}
	
	public void setStages(bool[] stages){
		this.stages = stages;
	}

	public bool[] getStages(){
		return this.stages;
	}

	public void setAchievements(bool[] achievements){
		this.achievements = achievements;
	}

	public bool[] getAchievements(){
		return this.achievements;
	}
}
