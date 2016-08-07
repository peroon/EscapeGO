using UnityEngine;
using System.Collections;

public class MonsterController : SingletonMonoBehaviour<MonsterController> {

	public float moveRadius = 2.0f;

	Vector3 initialPosition;

	public enum Position{
		LEFT,
		CENTER,
		RIGHT
	}
	public Position position = Position.CENTER;

	void Start () {
		initialPosition = this.transform.position;
	}
	
	void Update () {
	
	}


	public void OnClickRight(){
		//Debug.Log ("右へ");
		switch (this.position) {
		case Position.LEFT:
			MoveAbsolute (Position.CENTER);
			break;
		case Position.CENTER:
			MoveAbsolute (Position.RIGHT);
			break;
		case Position.RIGHT:
			break;
		}
	}

	public void OnClickLeft(){
		//Debug.Log ("左へ");
		switch (this.position) {
		case Position.LEFT:
			break;
		case Position.CENTER:
			MoveAbsolute (Position.LEFT);
			break;
		case Position.RIGHT:
			MoveAbsolute (Position.CENTER);
			break;
		}
	}

	void MoveAbsolute(Position toPosition){
		float x = 0.0f;
		switch (toPosition) {
		case Position.LEFT:
			x = -moveRadius;
			this.position = Position.LEFT;
			break;
		case Position.CENTER:
			x = 0;
			this.position = Position.CENTER;
			break;
		case Position.RIGHT:
			x = moveRadius;
			this.position = Position.RIGHT;
			break;
		}
		this.transform.position = new Vector3 (x, initialPosition.y, initialPosition.z);
	}
}
