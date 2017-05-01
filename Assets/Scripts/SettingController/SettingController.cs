using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : MonoBehaviour {

	public static SettingController instance;

	public GameObject SettingPanel;

	public GameObject SettingpanelBackground;

	public GameObject GameIntroduceBackground;

	private AudioSource bgMusic;

	public Text bgMusic_text;

	private float time;

	void Awake() {
		MakeSingleton();

		CreateAudio();
		PlayAudio();
	}

	void CreateAudio() {

		AudioSource[] audioSources = GetComponents<AudioSource>();//오디오 소스를 가져온다.
		bgMusic = audioSources[0];//첫번째 오디오 컴포넌트 bgMusic

	}

	void PlayAudio() {
		bgMusic.Play();
	}

	public void bgMusicButton() {
		if(GameManager.instance.isMusicOn){
			time = bgMusic.time;
			bgMusic.Stop();
			GameManager.instance.isMusicOn = false;
			bgMusic_text.text = "배경음 꺼짐";

		}else{
			bgMusic.time = time;
			bgMusic.Play();
			GameManager.instance.isMusicOn = true;

			bgMusic_text.text = "배경음 켜짐";
		}
	}

	void MakeSingleton() {//싱글톤 생성

		if (instance != null){
			Destroy(gameObject);
		}else{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OpenSettingPanel() {
	
		SettingPanel.SetActive(true);
	
	}

	public void CloseSettingPanel() {
		
		SettingPanel.SetActive(false);
	
	}

	public void OpenIntroducePanel() {
		
		SettingpanelBackground.SetActive(false);
		GameIntroduceBackground.SetActive(true);

	}

	public void CloseIntroducePanel(){

		SettingpanelBackground.SetActive(true);
		GameIntroduceBackground.SetActive(false);

	}

	public void GameIsLoadedTrunOffMusic(){
			time = bgMusic.time;
			bgMusic.Stop();
			GameManager.instance.isMusicOn = false;
	}

	public void GameIsOffTurnOnMusic(){
			bgMusic.time = time;
			bgMusic.Play();
			GameManager.instance.isMusicOn = true;
	}

}
