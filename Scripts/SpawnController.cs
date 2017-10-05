using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

public class SpawnController : MonoBehaviour {

	public GameObject zombie;
	public Button startButton;

	// Use this for initialization
	void Start() {
		
		startButton.onClick.AddListener(StartInvoke);
	}

	void StartInvoke() {
		
		InvokeRepeating("Spawn", 0f, 5f);
	}

	void Spawn() {

		Vector3 position = new Vector3(Random.Range(-10f, 10f), Random.Range(-3f, 3f), Random.Range(-10f, 10f));
		Instantiate(zombie, position, Quaternion.Euler(0, 0, 0));
	}
}
