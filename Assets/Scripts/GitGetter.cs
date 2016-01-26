using UnityEngine;
using System.Collections;
using SimpleJSON;

public class GitGetter : MonoBehaviour {
	public string url = "https://api.github.com/repos/jmccormack200/Stuntman/commits/master";
	public string sha = "";
	public string author = "";
	public string message = "";

	public GameObject title;
	public GameObject scrolling_text;

	public int repeatTime = 360;

	void Start(){
		print ("Test");
		//InvokeRepeating ("fetch_commits", 10, 360.0f);
		StartCoroutine(fetch_commits());
	}

	// Update is called once per frame
	void Update () {
			
	}

	IEnumerator fetch_commits(){
		while (true) {
			print ("test2");
			WWW www = new WWW (url);
			yield return www;
			print ("test3");
			var json = (JSON.Parse (www.text)) [0];

			sha = json ["sha"].Value;
			print ("Sha = " + sha);
			author = json ["commit"] ["author"] ["name"].Value;
			print ("name = " + author);
			message = json ["commit"] ["message"].Value;
			print ("message = " + message);

			title.GetComponent<MainTitleScroll> ().start_title = true;

			foreach (Transform transform in scrolling_text.transform) {
				if (transform.name == "Episode") {
					transform.GetComponent<TextMesh> ().text = "Episode:   " + sha.Substring (0, 7);
				} else {
					transform.GetComponent<MessageMeat> ().formatMessage (message, author);
				}
			}
			yield return new WaitForSeconds (repeatTime);
		}
	}
}
