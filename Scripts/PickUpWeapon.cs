using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour {

	public GameObject pickUpButton;
	public GameObject crossHair;

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision col) {

		if (col.gameObject.name == "pistol") {
			pickUpButton.gameObject.SetActive(true);
			crossHair.gameObject.SetActive(false);
		}
	}

	void OnCollisionExit(Collision col) {

		if (col.gameObject.name == "pistol") {
			pickUpButton.gameObject.SetActive(false);
			crossHair.gameObject.SetActive(true);
		}
	}
}
