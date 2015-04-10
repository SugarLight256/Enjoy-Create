using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

	public GameObject mis_value;
	public GameObject time_value;
	public GameObject score_value;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Text misText;
		Text timeText;
		Text scoreText;

		misText = mis_value.GetComponent<Text> ();
		timeText = time_value.GetComponent<Text> ();
		scoreText = score_value.GetComponent<Text> ();

		misText.text = ">>>"+scoreManager.misCount+"<<<";
		timeText.text = ">>>"+scoreManager.time+"<<<";
		scoreText.text = ">>>"+scoreManager.score+"<<<";

	}
}
