using UnityEngine;
using System.Collections;

public class MainTitleScroll : MonoBehaviour {

	public float speed = 1.0f;
	public GameObject message;
	public bool start_title = false;
	public Vector3 original_position;

	// Use this for initialization
	void Start () {
		transform.position.Set(-0.05f, 0.6f, 7.0f);
		original_position = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		TitleCrawl ();
	}

	public void SetTrue(){
		start_title = true;
	}

	public void SetFalse(){
		start_title = false;
	}

	public void TitleCrawl(){

		if (start_title == true) {
			start_title = false;
			gameObject.transform.position = original_position;
			gameObject.GetComponent<Renderer> ().enabled = true;

		} else {
			//was 158
			if (transform.position.z <= 158) {
				transform.position += Vector3.forward * Time.deltaTime * speed;
			} else {
				message.GetComponent<MessageScroll>().start = true;
				message.GetComponent<MessageScroll> ().ScrollMessage ();
				gameObject.GetComponent<Renderer>().enabled = false;
			}
		}
	}
}
