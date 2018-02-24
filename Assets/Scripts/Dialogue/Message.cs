using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message {
	public delegate void ChoiceCallback(DialogueScript dlg);

	public bool is_just_code = false;
	public ChoiceCallback callback;

	public string text;
	public List<KeyValuePair<string, string>> choices;

	private bool continues;

	public Message(string text) {
		this.is_just_code = false;
		this.text = text;
		this.choices = new List<KeyValuePair<string, string>> ();
	}

	public Message(ChoiceCallback callback, bool continues) {
		this.is_just_code = true;
		this.callback = callback;
		this.continues = continues;
		this.text = "";
		this.choices = new List<KeyValuePair<string, string>> ();
	}

	public void AddChoice(string text, string nextConversationName) {
		choices.Add(new KeyValuePair<string, string>(text, nextConversationName));
	}

	public bool Continues() {
		return continues;
	}
}
