using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {

	public Camera camOld;
	public Camera camNew;

	public Transform playerTransform;
	public Transform newLocation;

	void OnTriggerEnter2D(Collider2D other) {
		// change camera to new location
		camNew.gameObject.SetActive(true);
		camOld.gameObject.SetActive(false);

		// teleport character to new location
		playerTransform.position = newLocation.position;
	}
}