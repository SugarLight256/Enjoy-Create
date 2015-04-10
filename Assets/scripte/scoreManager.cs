using UnityEngine;
using System.Collections;

public class scoreManager : MonoBehaviour {

	public Canvas canvas;
	public static int misCount;
	public static int time;
	public static bool died;
	public static int score;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] mis_st;
		//Debug.Log ("" + score);
		if (Application.loadedLevelName == "play" && died == false) {
			time++;
			mis_st = GameObject.FindGameObjectsWithTag ("bullet_p");
			misCount = mis_st.Length;
			score =(int)(time/10 + misCount*100);
		}
	}
	public static void reset(){
		misCount = 0;
		time = 0;
		died = false;
		score = 0;
	}
}
