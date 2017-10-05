using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithCamera : MonoBehaviour {

	public bool zombieIsThere;
	float timer;
	int timebetweenAttack;
	Animator anim;
	private GameControllerScript gameController;
	AudioSource attackSound;

	void Awake() {
		
		anim = GetComponent<Animator>();
	}
	// Use this for initialization
	void Start() {
		
		timebetweenAttack = 2;

		GameObject gameControllerObject = GameObject.FindWithTag("GameController");

		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameControllerScript>();
		}

		AudioSource[] audios = GetComponents<AudioSource>();
		attackSound = audios[0];
	}
	
	// Update is called once per frame
	void Update() {

		timer += Time.deltaTime;

		if (zombieIsThere && timer >= timebetweenAttack) {
			Attack();
		}
	}

	void OnCollisionEnter(Collision col) {
		
		if (col.gameObject.tag == "MainCamera") {
			zombieIsThere = true;
		}
	}

	void OnCollisionExit(Collision col) {
		
		if (col.gameObject.tag == "MainCamera") {
			zombieIsThere = false;
		}
	}

	void Attack() {
		
		timer = 0;
		anim.Play("attack");
		gameController.zombieAttack(zombieIsThere);
		attackSound.Play();
	}
		
}
