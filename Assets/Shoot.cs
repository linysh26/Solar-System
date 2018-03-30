using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public float speed = 100000f;

	// Use this for initialization
	void Start () {
		ShootingStar ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ShootingStar(){
		Rigidbody rigid_body = this.GetComponent<Rigidbody> ();
		rigid_body.AddForce (this.transform.forward * speed);
	}
}
