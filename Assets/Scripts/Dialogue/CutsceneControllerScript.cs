using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CutsceneControllerScript : MonoBehaviour
{
	private class Timer {
		public DialogueScript dlg;
		public float startSeconds;
		public float seconds;
		public SavedDialogueState dlgState;

		public Timer(DialogueScript dlg, float startSeconds, float seconds, SavedDialogueState dlgState) {
			this.dlg = dlg;
			this.startSeconds = startSeconds;
			this.seconds = seconds;
			this.dlgState = dlgState;
		}
	}

	private List<Timer> timers;

	void Start() {
		timers = new List<Timer> ();
	}

	// Update is called once per frame
	void Update ()
	{
		List<Timer> timersToStop = new List<Timer>();

		foreach (Timer t in timers) {
			if (Time.time >= t.startSeconds + t.seconds) {
				t.dlg.ResumeConversation (t.dlgState);
				timersToStop.Add (t);
			}
		}

		foreach (Timer t in timersToStop) {
			timers.Remove (t);
		}
	}

	public void Delay(DialogueScript dlg, float seconds, SavedDialogueState dlgState) {
		timers.Add (new Timer (dlg, Time.time, seconds, dlgState));
	}
}

