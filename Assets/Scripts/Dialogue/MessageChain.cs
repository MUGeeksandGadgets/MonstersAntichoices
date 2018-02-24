﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageChain {
	private List<Message> list;

	public MessageChain() {
		list = new List<Message> ();
	}

	public MessageChain msg(string text) {
		list.Add (new Message (text));
		return this;
	}

	public MessageChain choice(string text, Message.ChoiceCallback callback) {
		list[list.Count - 1].AddChoice(text, callback);
		return this;
	}

	public Message Get(int index) {
		if (index < 0 || index >= list.Count)
			return null;
		
		return list [index];
	}
}