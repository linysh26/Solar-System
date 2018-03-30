using UnityEngine;
using System.Collections;

public class GlobalController : MonoBehaviour {

	private int star_dust_counter = 0;

	// Use this for initialization
	void Start () {
		Transform[] children = this.gameObject.GetComponentsInChildren<Transform> ();
		int i = 1;
		foreach(Transform child in children) {
			if (child.name == "moon")
				continue;
			float y = (float)Random.Range (0, 5);
			float z = (float)Random.Range (0, 10 * i);
			float x = Mathf.Sqrt (100 * i * i - z * z);
			child.transform.position = new Vector3 (x, y, z);
			i++;
		}

		StartCoroutine (Kuiper_Generator ());
		StartCoroutine (Comet_Generator ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator Kuiper_Generator(){
		while(true){
			int type = Random.Range (1, 4);
			float x = (float)(Random.Range (-1000, 1000) / 10.0);
			float z = Mathf.Sqrt (100 * 100 - x * x) * (star_dust_counter % 2 == 0 ? 1 : -1);
			GameObject star_dust = (GameObject)Instantiate (Resources.Load("Free_Rocks/_prefabs/rock" + type), new Vector3(x, 0, z), Quaternion.identity);
			star_dust.transform.parent = this.transform;
			star_dust.GetComponent<PlanetActionController> ().speed_public = (float)Random.Range (5, 10);
			star_dust_counter++;
			if (star_dust_counter == 100)
				yield break;
			yield return star_dust_counter;
		}
	}

	IEnumerator Comet_Generator(){
		while (true) {
			yield return new WaitForSeconds (8.0f);
			GameObject shooting_star = Instantiate (Resources.Load ("Comet"), new Vector3 (0, 50, -200), Quaternion.Inverse (Quaternion.identity)) as GameObject;
			GameObject shooting_star_tail = Instantiate (Resources.Load ("comet_tail"), new Vector3 (0, 50, -200), Quaternion.identity) as GameObject;
			shooting_star_tail.transform.parent = shooting_star.transform;
			Destroy (shooting_star, 10.0f);
		}
	}
}
