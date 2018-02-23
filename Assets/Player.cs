using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	Direction currentDir;
	Vector2 input;
	bool isMoving = false;
	Vector3 startPos;
	Vector3 endPos;
	float t;

	public float walkSpeed = 3f;

	public Sprite northSprite;
	public Sprite eastSprite;
	public Sprite southSprite;
	public Sprite westSprite;


	// Update is called once per frame
	void Update () {
		if (!isMoving) {
			input = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
			if (Mathf.Abs (input.x) > Mathf.Abs(input.y)) {
				input.y = 0;
			} else {
				input.x = 0;
			}
			if (input != Vector2.zero) {
				if (input.x < 0) {
					currentDir = Direction.West;
				}
				if (input.x > 0) {
					currentDir = Direction.East;
				}
				if (input.y > 0) {
					currentDir = Direction.North;
				}

				if (input.y < 0) {
					currentDir = Direction.South;
				}

				switch (currentDir) {
				case Direction.North:
					gameObject.GetComponent<SpriteRenderer> ().sprite = northSprite;
					break;
				case Direction.East:
					gameObject.GetComponent<SpriteRenderer> ().sprite = eastSprite;
					break;
				case Direction.South:
					gameObject.GetComponent<SpriteRenderer> ().sprite = southSprite;
					break;
				case Direction.West:
					gameObject.GetComponent<SpriteRenderer> ().sprite = westSprite;
					break;
				}
				StartCoroutine (Move (transform));
			}
		}
	}

	public IEnumerator Move(Transform entity){
		isMoving = true;
		//Gets entity's current pos
		startPos = entity.position;
		t = 0;//Math.sign simply flattens the number to either 1 or -1
		endPos = new Vector3 (startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign (input.y), startPos.z);


		while (t < 1f) {
			//Gives the amount of time that it takes to move from block to block
			t += Time.deltaTime * walkSpeed;
			entity.position = Vector3.Lerp(startPos, endPos, t);
			yield return null;
		}

		isMoving = false;
		yield return 0;
	}


}

enum Direction{

	North,
	East,
	South,
	West
}
