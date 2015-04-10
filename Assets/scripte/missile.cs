using UnityEngine;
using System.Collections;

public class missile : MonoBehaviour {

	float rotSpeed = 5.0f;
	float speed = 50.0f;
	float direction;

	bool targetFlag;
	int lifeTime = 0;



	public GameObject myTarget;

	// Use this for initialization
	void Start () {
		Vector2 dir = new Vector2 (GameObject.Find ("enemy").GetComponent<enemy> ().vx,
		                           GameObject.Find ("enemy").GetComponent<enemy> ().vy);
		rigidbody2D.velocity = dir;
		direction =Mathf.Atan2 (rigidbody2D.velocity.y, rigidbody2D.velocity.x) * Mathf.Rad2Deg;
	}

	void SetVelocity(float direction, float speed){
		
		var vx = Mathf.Cos (Mathf.Deg2Rad * direction) * speed;
		var vy = Mathf.Sin (Mathf.Deg2Rad * direction) * speed;
		
		rigidbody2D.velocity = new Vector2 (vx, vy);
		
	}
	
	void Update () {
		lifeTime++;
		Vector3 next = transform.position;

		if (lifeTime >= 30)
			targetFlag = true;

		if (myTarget == null) {
			myTarget = target (gameObject , "enemy");
		}
		if (targetFlag == true) {
			var renderer = GetComponent<SpriteRenderer> ();
			renderer.transform.localRotation = Quaternion.Euler (new Vector3 (0, 0, direction-90));
			next = myTarget.transform.position;
			Vector3 now = transform.position;

			var d = next - now;
			var targetAngle = Mathf.Atan2 (d.y, d.x) * Mathf.Rad2Deg;
			var deltaAngle = Mathf.DeltaAngle (direction, targetAngle);
			if (Mathf.Abs (deltaAngle) < rotSpeed) {
			
			} else if (deltaAngle > 0) {
				direction += rotSpeed;
			} else if (deltaAngle < 0) {
				direction -= rotSpeed;
			}
		}

		SetVelocity (direction, speed);

	}

	void OnTriggerEnter2D(Collider2D c){
		scoreManager.died = true;
		Destroy (this.gameObject);
		Application.LoadLevel("GameOver");
	}

	public GameObject target(GameObject myObj,string nameTag){
		float tmpDis = 0; //距離一時保存
		float nearDis = 0; //最短距離オブジェクトとの距離
		GameObject targetObj = null;

		foreach (GameObject objs in GameObject.FindGameObjectsWithTag(nameTag)) {
			//距離を算出
			tmpDis = Vector2.Distance(objs.transform.position, myObj.transform.position);
			//今までの最短と比べて更に近いかどうか
			if(nearDis == 0 || nearDis > tmpDis){
				nearDis = tmpDis;//最短距離を記録
				targetObj = objs;//オブジェクト保存
			}
		}
		return targetObj;//最短距離のオブジェクトを返す
	}
}
