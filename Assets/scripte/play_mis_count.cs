using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class play_mis_count : MonoBehaviour {

	public GameObject mis_value;
	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
		Text misText;

		misText = mis_value.GetComponent<Text> ();

		misText.text = "Mis Count : " + scoreManager.misCount;


	}
}
