using UnityEngine;
using System.Collections;

public class DestroyCube : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.tag == "PokeBall") {
			Destroy (other.gameObject);
		}
	}
}
