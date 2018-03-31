using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	float gravity_acceleration = 9.8f;
	float initial_forward_speed = 10.0f;
	float initial_upward_speed = 10.0f;
	float x_distance = 0;
	float y_distance = 0;

	// Use this for initialization
	void Start () {
		//Throw();
	}
	
	// Update is called once per frame
	void Update () {
		//method 1st gravity simulation
		x_distance += initial_forward_speed * Time.deltaTime;
		y_distance += initial_upward_speed * Time.deltaTime;
		initial_upward_speed -= gravity_acceleration * Time.deltaTime;
		this.transform.position = new Vector3 (x_distance + initial_forward_speed * Time.deltaTime, y_distance, 0);
	}


	//method 3rd use rigidbody
	void Throw(){
		//add Rigidbody
		Rigidbody rb = this.GetComponent<Rigidbody>();

		//intialize velocity
		rb.velocity(new Vector3(10, 10, 10));
		//set gravity available after throwing
		rb.useGravity (true);
		//also we can use addForce(new Vector3)
	}
}
