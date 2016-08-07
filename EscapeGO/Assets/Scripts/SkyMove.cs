using UnityEngine;
using System.Collections;

public class SkyMove : MonoBehaviour {

	public float rotateSpeed;
	Vector3 initialRotation;

	void Start(){
		this.initialRotation = this.transform.localRotation.eulerAngles;
		StartCoroutine (RotateCoroutine ());
	}

	IEnumerator RotateCoroutine(){
		while (true) {
			var x = this.initialRotation.x;
			var z = this.initialRotation.z;
			var y = Time.time * rotateSpeed;

			this.transform.localRotation = Quaternion.Euler (x, y, z);

			yield return new WaitForSeconds (0.1f);
		}
	}

	void Update () {

	}
}
