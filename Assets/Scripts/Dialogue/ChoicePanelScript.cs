using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoicePanelScript : MonoBehaviour {
	public Text text;
	public GameObject dlgCanvas;
	public Text cursor;

	private List<KeyValuePair<string, Message.ChoiceCallback>> choices;
	private int selection;
	private DialogueScript dlgScript;

	public void Start() {
		dlgScript = dlgCanvas.GetComponent<DialogueScript> ();
	}

	public void Update() {
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {
			if (selection > 0)
				selection--;
			
			cursor.transform.localPosition = new Vector3(cursor.transform.localPosition.x, text.transform.localPosition.y + (choices.Count - selection) * cursor.font.lineHeight, cursor.transform.localPosition.z);
		} else if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) {
			if (selection < choices.Count - 1)
				selection++;

			cursor.transform.localPosition = new Vector3(cursor.transform.localPosition.x, text.transform.localPosition.y + (choices.Count - selection) * cursor.font.lineHeight, cursor.transform.localPosition.z);
		} else if (Input.GetKeyDown (KeyCode.Space)) {
			Message.ChoiceCallback callback = choices [selection].Value;
			callback (dlgScript);
		}
	}

	public void UpdateChoices(List<KeyValuePair<string, Message.ChoiceCallback>> choices) {
		string s = "";

		for (int i = 0; i < choices.Count; i++) {
			s += choices [i].Key;
			s += "\n";
		}

		text.text = s;

		selection = 0;
		this.choices = choices;
	}
}
