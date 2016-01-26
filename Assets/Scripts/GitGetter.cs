using UnityEngine;
using System.Collections;
using SimpleJSON;

public class GitGetter : MonoBehaviour {
	//Uncomment For Stuntman Project
	//public string url = "https://api.github.com/repos/jmccormack200/Stuntman/commits/master";
	//Uncomment for This Project
	public string url = "https://api.github.com/repos/jmccormack200/GitWars/commits/master";
	public string sha = "";
	public string last_sha = "";
	public string author = "";
	public string message = "";

	public GameObject title;
	public GameObject scrolling_text;

	public int repeatTime = 60;

	void Start(){
		StartCoroutine(fetch_commits());
	}

	IEnumerator fetch_commits(){
		while (true) {

			WWW www = new WWW (url);
			yield return www;

			var json = (JSON.Parse (www.text)) [0];

			sha = json ["sha"].Value;
			author = json ["commit"] ["author"] ["name"].Value;
			message = json ["commit"] ["message"].Value;

			if (last_sha != sha) {
				
				title.GetComponent<MainTitleScroll> ().PrepareCrawl ();
				title.GetComponent<MainTitleScroll> ().TitleCrawl ();


				foreach (Transform transform in scrolling_text.transform) {
					if (transform.name == "Episode") {
						transform.GetComponent<TextMesh> ().text = "Episode:   " + sha.Substring (0, 7);
					} else {
						transform.GetComponent<MessageMeat> ().formatMessage (message, author);
					}
				}
				last_sha = sha;
			}


			yield return new WaitForSeconds (repeatTime);

		}
	}
}
