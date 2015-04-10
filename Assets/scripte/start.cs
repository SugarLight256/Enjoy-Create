using UnityEngine;
using System.Collections;

public class start : MonoBehaviour {

	private bool back;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
			if(Application.loadedLevelName=="menu"){
				Application.LoadLevel("play");

			}else if(Application.loadedLevelName == "GameOver" && back == true){
				scoreManager.reset();
				Application.LoadLevel("menu");
			}
			back = true;
		}
	}
}
