using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
		// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			float tx = Input.GetTouch (0).position.x;
			float ty = Input.GetTouch (0).position.y;
			transform.position = Camera.main.ScreenToWorldPoint( new Vector3(tx,ty));
		}
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended){
			scoreManager.died = true;
			Application.LoadLevel("GameOver");

		}
	}
}
