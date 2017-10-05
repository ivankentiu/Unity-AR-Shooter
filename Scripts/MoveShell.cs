using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Remoting;

public class MoveShell : MonoBehaviour {

	private Rigidbody rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>();
		StartCoroutine("Rotate");
		StartCoroutine("Wait");
		Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {

		rb.AddForce(transform.right * 0.05f);
		rb.AddForce(transform.up * 0.05f);
	}

	IEnumerator Rotate() {
		while(true) {
			yield return new WaitForSeconds(0.1f);
			transform.eulerAngles += new Vector3(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360));
		}
	}

	IEnumerator Wait() {
		yield return new WaitForSeconds(0.2f);
		rb.useGravity = true;
		yield return new WaitForSeconds(0.2f);

		AudioSource shell = GetComponent<AudioSource>();
		shell.Play();
	}
}
