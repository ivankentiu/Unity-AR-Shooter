using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.iOS;

public class StartGame : MonoBehaviour {

	public Button startButton;
	private UnityARHitTestExample unityARHitTestExample;
	public Image crosshair;

	// Use this for initialization
	void Start () {

		startButton.onClick.AddListener(StartNewGame);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void StartNewGame() {

		unityARHitTestExample = GetComponent<UnityARHitTestExample>();
		Destroy(unityARHitTestExample);
		startButton.gameObject.SetActive(false);
		crosshair.gameObject.SetActive(true);
	}
}
