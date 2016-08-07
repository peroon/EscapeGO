using UnityEngine;
using System.Collections;

public class BallShooter : SingletonMonoBehaviour<BallShooter> {

	// 参照
	public Transform target;
	public GameObject ballPrefab;
	public Animator trainerAnimator;

	// パラメータ
	public float interval = 2.0f;
	public float force = 30;
	public bool easyRandomThrow = false;

	public int level = 1;
	private Coroutine shootCoroutine;

	void Start () {
	}

	IEnumerator ShootCoroutine(){
		while (true) {
			yield return new WaitForSeconds (interval);
			Shoot ();
		}
	}

	// ゲーム開始時に外部から呼ぶ
	public void StartShoot(){
		shootCoroutine = StartCoroutine (ShootCoroutine ());
	}

	public void Stop(){
		StopCoroutine (shootCoroutine);
	}

	void Shoot(){
		SoundManager.Instance.PlaySE (SE.SHOOT);
		var ball = Instantiate (ballPrefab, this.transform.position, Quaternion.identity) as GameObject;
		//Destroy (ball, 10.0f);
		var rigidBody = ball.GetComponent<Rigidbody> ();

		var targetPosition = target.position;
		var moveRadius = MonsterController.Instance.moveRadius;
		// 3方向ランダム
		if (easyRandomThrow) {
			var r = Random.value;
			if (r < 0.333) {
				targetPosition.x = moveRadius;
			} else if (r < 0.666) {
				targetPosition.x = -moveRadius;
			} else {
				targetPosition.x = 0.0f;
			}
		}

		// 方向
		rigidBody.AddForce ((targetPosition - this.transform.position).normalized * force);

		// 回転
		rigidBody.AddTorque(new Vector3(Random.value * 1000.0f, Random.value * 1000.0f, Random.value * 1000.0f));

		// UI
		Game.Instance.IncrementCP ();

		// アニメーション
		this.trainerAnimator.SetTrigger("throwTrigger");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LevelUp(){
		level++;
		switch (level) {
		case 2:
			interval = 1.0f;
			force = 60;
			break;

		case 3:
			easyRandomThrow = true;
			break;

		case 4:
			easyRandomThrow = false;
			interval = 0.9f;
			break;

		case 5:
			easyRandomThrow = true;
			break;


		case 6:
			easyRandomThrow = false;
			interval = 0.8f;
			break;

		case 7:
			easyRandomThrow = true;
			break;

		case 8:
			easyRandomThrow = false;
			interval = 0.7f;
			break;

		case 9:
			easyRandomThrow = true;
			break;

		}
	}
}
