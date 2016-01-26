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
	
	// Update is called once per frame
	void Update () {
		if (start) {
			if (transform.position.z <= 350) {
				transform.position += (new Vector3 (0, 1, 1)) * Time.deltaTime * speed;
			} else {
				gameObject.transform.position = original_position;
				start = false;
			}
		}
	}
}
