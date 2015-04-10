using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public float vx;
	public float vy;
	public float speed;
	public Camera cam;
	public Vector3 direction;
	// Use this for initialization
	void Start () {
		vx = Random.Range (-10, 10);
		vy = Random.Range (-10, 10);
		direction = new Vector2(vx, vy).normalized;
		transform.rotation = Quaternion.FromToRotation(Vector3.up , direction);
	}
	
	// Update is called once per frame
	void Update () {

		transform.rotation = Quaternion.FromToRotation(Vector3.up , direction);
		var leftDown_Pos =cam.ViewportToWorldPoint( new Vector3 (0, 0, 0));
		var rightUp_Pos =cam.ViewportToWorldPoint( new Vector3 (1, 1, 0));

		if (transform.position.x <= leftDown_Pos.x || 
		    transform.position.x >= rightUp_Pos.x) {
			vx *= -1;
			audio.Play();
		}
		if (transform.position.y <= leftDown_Pos.y ||
			transform.position.y >= rightUp_Pos.y) {
			vy *= -1;
			audio.Play();
		}
		direction = new Vector2(vx, vy).normalized;
		rigidbody2D.velocity =direction * speed;
	}
}
