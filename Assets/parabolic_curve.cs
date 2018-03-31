using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	float gravity_acceleration = 9.8f;
	float initial_forward_speed = 10.0f;
	float initial_upward_speed = 10.0f;
	float x_distance = 0;
	float y_distance = 0;

	float distance_to_target = 10;
	Vector3 target_position;
	

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
		this.transform.position = new Vector3 (x_distance, y_distance, 0);

		//method 2nd change rotation and use Translate, initialize rotation 45, 0, 0
		target_position = new Vector3();
		this.transform.LookAt(target_position);
		//get the angle according to the x_coodinate -> f’(x_coordinate) 
		this.transform.rotation = this.transform.rotation * Quaternion.Euler (Mathf.Clamp (-angle, -42, 42), 0, 0);
		this.transform.rotation = this.transform.rotation * Quaternion.Euler (-angle, 42, 42);
		//move toward the current angle
		this.transform.Translate (Vector3.forward * Mathf.Min (speed * Time.deltaTime, currentDist));
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
