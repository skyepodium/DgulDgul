using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour {

	public static MusicController instance;

	private AudioSource bgMusic, click;

	private float time;

	// Use this for initialization
	void Awake () {
		MakeSingleton();//씬이 시작되면 싱글톤 생성함수 호출

		AudioSource[] audioSources = GetComponents<AudioSource>();//오디오 소스를 가져온다.

		bgMusic = audioSources[0];//첫번째 오디오 컴포넌트 bgMusic
		click = audioSources[1];//두번째 오디오 컴포넌트 click
	}

		void MakeSingleton() {//싱슬톤 생성
		if (instance != null){
			Destroy(gameObject);
		}else{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

}
