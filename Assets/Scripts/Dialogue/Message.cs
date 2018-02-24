using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message {
	public delegate void ChoiceCallback();

	public string text;
	public List<KeyValuePair<string, ChoiceCallback>> choices;

	public Message(string text) {
		this.text = text;
		choices = new List<KeyValuePair<string, ChoiceCallback>> ();
	}

	public void AddChoice(string text, ChoiceCallback callback) {
		choices.Add(new KeyValuePair<string, ChoiceCallback>(text, callback));
	}
}
