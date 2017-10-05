using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootEnemy : MonoBehaviour {

	public Button shootButton;
	public Camera fpsCam;
	public float damage = 10f;
	public GameObject bloodEffect;
	public GameObject shootingEffect;
	public int forceAdd = 300;
	AudioSource shootSound;
	AudioSource reloadSound;
	public Text ammo1Text;
	public Text ammo2Text;
	public int ammo1;
	public int ammo2;
	private bool ammoIsEmpty;
	public ParticleSystem muzzleFlash;
	public GameObject pistolGO;
	private bool reloadCheck;
	public GameObject shell;

	// Use this for initialization
	void Start() {

		shootButton.onClick.AddListener(OnShoot);

		AudioSource[] audios = GetComponents<AudioSource>();
		shootSound = audios[0];
		reloadSound = audios[1];

		ammo1 = 20;
		ammo2 = 100;
		reloadCheck = true;
	}

	IEnumerator WaitForReload() {
		yield return new WaitForSeconds(3f);
		reloadCheck = true;
	}



	void OnShoot() {

		if (!ammoIsEmpty && reloadCheck) {
			// Ammo

			if (ammo1 == 1) {
				ammo1 = 21;
				pistolGO.GetComponent<Animator>().SetTrigger("reload");
				reloadCheck = false;
				StartCoroutine(WaitForReload());
				reloadSound.Play();
			} 

			ammo1 -= 1;
			string ammo1String = ammo1.ToString();
			ammo1Text.text = ammo1String;

			ammo2 -= 1;
			string ammo2String = ammo2.ToString();
			ammo2Text.text = "/ " + ammo2String;

			if (ammo2 == 0) {
				ammoIsEmpty = true;
				ammo1 = 0;
				string ammo11String = ammo1.ToString();
				ammo1Text.text = ammo11String;
			}

			// Raycasting

			RaycastHit hit;
			if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit)) {

				Enemy target = hit.transform.GetComponent<Enemy>();

				if (target != null) {
					target.TakeDamage(damage);
					GameObject bloodGO = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
					Destroy(bloodGO, 0.2f);
				} else {
					GameObject shootingGO = Instantiate(shootingEffect, hit.point, Quaternion.LookRotation(hit.normal));
					Destroy(shootingGO, 0.2f);
				}

				if (hit.rigidbody != null) {
					hit.rigidbody.AddForce(-hit.normal * forceAdd);
				}
			}
			// Sound and Animation Play

			muzzleFlash.Play();
			shootSound.Play();
			pistolGO.GetComponent<Animator>().Play("Fire");

			// Loading Shell

			Vector3 position = GameObject.FindGameObjectWithTag("positionPistol").transform.position;
			Quaternion rotation = Quaternion.Euler(0, 0, 0);

			Instantiate(shell, position, rotation);
		}

	}
}
