using UnityEngine;
using System.Collections;

public class OnCollidePokeBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "PokeBall") {
			Debug.Log ("ゲームオーバー");
			GameOverPanel.Instance.Show ();

			BallShooter.Instance.Stop ();

			this.transform.localScale = Vector3.zero; // ポケモンのスケール０
//			other.GetComponent<Rigidbody> ().velocity = Vector3.zero;

			var dir = (other.transform.position - this.transform.position).normalized;
			other.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			other.GetComponent<Rigidbody> ().AddForce (Vector3.forward);
		}
	}
}
