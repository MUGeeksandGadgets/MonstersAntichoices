using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	Direction currentDir;
	Vector2 input;
	bool isMoving = false;
	Vector3 startPos;
	Vector3 endPos;
	Vector3 lastPos;
	float t;
	bool noBlock = false;

	public float walkSpeed = 3f;
	float dist = 0.1f;
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
				RaycastHit2D hit = Physics2D.Raycast (transform.position, -Vector2.up);
				switch (currentDir) {
				case Direction.North:
					gameObject.GetComponent<SpriteRenderer> ().sprite = northSprite;
					hit = Physics2D.Raycast (transform.position, Vector2.up, dist);
					if (hit.collider != null) {
						noBlock = true;
					} else {
						noBlock = false;
					}
					break;
				case Direction.East:
					gameObject.GetComponent<SpriteRenderer> ().sprite = eastSprite;
					hit = Physics2D.Raycast (transform.position, Vector2.right, dist);
					if (hit.collider.tag == "Wall") {
						noBlock = true;
					} else {
						if (hit.distance <= dist) {
							noBlock = false;
							print ("Hit wall");
						}
					}
					break;
				case Direction.South:
					gameObject.GetComponent<SpriteRenderer> ().sprite = southSprite;
					hit = Physics2D.Raycast (transform.position, Vector2.down, dist);
					if (hit.collider != null) {
						noBlock = true;
					} else {
						noBlock = false;
					}
					break;
				case Direction.West:
					gameObject.GetComponent<SpriteRenderer> ().sprite = westSprite;
					hit = Physics2D.Raycast (transform.position, Vector2.left, dist);
					if (hit.collider != null) {
						noBlock = true;
					} else {
						noBlock = false;
					}
					break;
				}
				if (noBlock == true) {
					StartCoroutine (Move (transform));
				}
			}
		}
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "wall") {
			transform.position = lastPos;
			print ("Hit Wall");
		}
	}
	public IEnumerator Move(Transform entity){
		isMoving = true;
		//Gets entity's current pos
		startPos = entity.position;
		t = 0;//Math.sign simply flattens the number to either 1 or -1
		endPos = new Vector3 (startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign (input.y), startPos.z);
		lastPos = entity.position;
		
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
