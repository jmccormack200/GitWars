using UnityEngine;
using System.Collections;

public class MessageMeat : MonoBehaviour {

	public string message = "";
	public string author = "";
	public int linelength = 11;

	public void formatMessage(string message, string author){
		string outputstring = ResolveTextSize (message, linelength);
		outputstring += "\n";
		outputstring += " - " + author;

		gameObject.GetComponent<TextMesh> ().text = outputstring;

	}

	private string ResolveTextSize(string input, int linelength){

		string[] words = input.Split (" " [0]);

		string result = "";

		string line = "";

		foreach (string s in words){
			string temp = line + " " + s;

			if (temp.Length > linelength) {
				result += line + "\n";
				line = s;
			} else {
				line = temp;
			}
		}
		result += line;
		return result.Substring (1, result.Length - 1);

	}
}
