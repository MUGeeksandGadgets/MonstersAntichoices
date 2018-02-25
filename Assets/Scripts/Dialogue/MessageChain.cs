using System.Collections;
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

	public MessageChain turnNPC(string npcName, string direction) {
		list.Add (new Message ((dlg) => {
			GameObject.Find(npcName).GetComponent<NPC_Behavior>().SetDirection(direction);
		}, true));
		return this;
	}

	public MessageChain moveNPC(string npcName, string direction, int numSpaces) {
		list.Add (new Message ((dlg) => {
			GameObject.Find (npcName).GetComponent<NPC_Behavior> ().Move (direction, numSpaces);
		}, true));
		return this;
	}

	public MessageChain choice(string text, string nextConversationName) {
		list[list.Count - 1].AddChoice(text, nextConversationName);
		return this;
	}

	public MessageChain freeze_player() {
		list.Add (new Message ((dlg) => {
			GameObject.Find("Player").GetComponent<Player>().Freeze();
		}, true));
		return this;
	}

	public MessageChain unfreeze_player() {
		list.Add (new Message ((dlg) => {
			GameObject.Find("Player").GetComponent<Player>().Unfreeze();
		}, true));
		return this;
	}

	public MessageChain freeze_npc(string name) {
		list.Add (new Message ((dlg) => {
			GameObject.Find(name).GetComponent<NPC_Behavior>().Freeze();
		}, true));
		return this;
	}

	public MessageChain unfreeze_npc(string name) {
		list.Add (new Message ((dlg) => {
			GameObject.Find(name).GetComponent<NPC_Behavior>().Unfreeze();
		}, true));
		return this;
	}

	public MessageChain wait_seconds(float seconds) {
		list.Add (new Message ((dlg) => {
			dlg.HideUI();
			GameObject.Find("Cutscene Controller").GetComponent<CutsceneControllerScript>().Delay(dlg, seconds, dlg.GetNextState());
		}, false));
		return this;
	}

	public MessageChain sound(string name) {
		list.Add (new Message ((dlg) => {
			GameObject.Find("Cutscene Controller").GetComponent<CutsceneControllerScript>().PlaySound(name);
		}, true));
		return this;
	}

	public Message Get(int index) {
		if (index < 0 || index >= list.Count)
			return null;
		
		return list [index];
	}
}
