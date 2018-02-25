using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDefs {
	public static MessageChain getConversation(string name) {
		// Things we need:
		//   Rotate Camera
		//   Pan Camera
		//   Change sprite animation
		//   Start move
		//   Change scene (with transition)


		if (name.Equals ("OakHello")) {
			return new MessageChain ()
				.freeze_player ()
				.freeze_npc("Oak")
				.msg ("Oh, my nephew has arrived.")
				.moveNPC ("Oak", "WEST", 4)
				.wait_seconds (NPC_Behavior.TIME_TO_MOVE_ONCE * 4)
				.wait_seconds (0.3f)
				.moveNPC ("Oak", "EAST", 4)
				.wait_seconds (NPC_Behavior.TIME_TO_MOVE_ONCE * 4)
				.wait_seconds (1.0f)
				.msg ("But where's my other nephew?")
				.unfreeze_npc("Oak")
				.unfreeze_player ();
			
		} else if (name.Equals ("GoingElsewhere")) {
			return new MessageChain()
				.freeze_player()
				// ...
				.unfreeze_player();
		}

		return null;
	}
}
