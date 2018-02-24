using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message {
	public delegate void ChoiceCallback(DialogueScript dlg);

	public bool is_just_code = false;
	public ChoiceCallback callback;

	public string text;
	public List<KeyValuePair<string, ChoiceCallback>> choices;

	public Message(string text) {
		this.is_just_code = false;
		this.text = text;
		this.choices = new List<KeyValuePair<string, ChoiceCallback>> ();
	}

	public Message(ChoiceCallback callback) {
		this.is_just_code = true;
		this.callback = callback;
	}

	public void AddChoice(string text, ChoiceCallback callback) {
		choices.Add(new KeyValuePair<string, ChoiceCallback>(text, callback));
	}
}
