using UnityEngine;
using System.Collections;

public class PlanetActionController : MonoBehaviour {

	public float speed_public;
	public float speed_self;
	private float x;
	private float z;
	private float y;
	private float radius_plane;
	// Use this for initialization
	void Start () {
		if (this.transform.name == "Earth") {
			Transform[] earth_moon_system = this.transform.GetComponentsInChildren<Transform> ();
			earth_moon_system [1].transform.position = new Vector3 (1, 0, 1);
		}
		this.z = transform.position.z;
		this.y = transform.position.y;
		this.x = transform.position.x;
		this.radius_plane = Mathf.Sqrt (x * x + z * z);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.RotateAround (this.transform.parent.position, new Vector3 (Mathf.Abs(y) * z / radius_plane * -1, radius_plane, Mathf.Abs(y) * x / radius_plane * -1), Time.deltaTime * speed_public);
		this.transform.Rotate (Vector3.up * Time.deltaTime * speed_self);
	}
}
