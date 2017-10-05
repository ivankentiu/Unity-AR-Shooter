using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPickup : MonoBehaviour {

	public Button pickUpButton;
	public GameObject weapon1;

	// Use this for initialization
	void Start () {

		pickUpButton.onClick.AddListener(Weapon1True);
	}
	
	void Weapon1True() {
		weapon1.gameObject.SetActive(true);
	}
}
