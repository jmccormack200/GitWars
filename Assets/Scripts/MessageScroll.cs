using UnityEngine;
using System.Collections;

public class MessageScroll : MonoBehaviour {

	public float speed = 1.0f;
	public bool start = false;
	public Vector3 original_position;


	// Use this for initialization
	void Start () {
		original_position = gameObject.transform.position;
	}

	void Update(){
		ScrollMessage ();
	}
	public void ScrollMessage () {
		
		if (start == true) {
			gameObject.transform.position = original_position;
		} else {
			//was 350
			if (transform.position.z <= 350) {
				transform.position += (new Vector3 (0, 1, 1)) * Time.deltaTime * speed;
			} else {
				start = false;
			}
		} 
	}
}

