using UnityEngine;
using System.Collections;

public class W_missile : MonoBehaviour {
	
	public float coolDown;
	public GameObject bullet;
	public GameObject parent;
	// Use this for initialization
	IEnumerator Start () {
		while (true) {
			//生成
			Instantiate(bullet,transform.position,transform.rotation);
			audio.Play();
			//coolDown秒待機
			yield return new WaitForSeconds(coolDown);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.FromToRotation(Vector3.up , parent.GetComponent<enemy>().direction);
	}
}
