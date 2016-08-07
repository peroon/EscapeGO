using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : SingletonMonoBehaviour<Game>{

	public Text cpText;
	public int cp;
	

	void Start () {
		Debug.Log ("BGM");
		SoundManager.Instance.PlayBGM (0);
	
		cp = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void IncrementCP(){
		cp++;
		cpText.text = "CP " + cp;

		switch (cp) {
		case 3:
			BallShooter.Instance.LevelUp ();
			break;
		case 10:
			BallShooter.Instance.LevelUp ();
			break;
		case 20:
			BallShooter.Instance.LevelUp ();
			break;
		case 30:
			BallShooter.Instance.LevelUp ();
			break;
		case 40:
			BallShooter.Instance.LevelUp ();
			break;
		case 50:
			BallShooter.Instance.LevelUp ();
			break;
		case 60:
			BallShooter.Instance.LevelUp ();
			break;
		case 70:
			BallShooter.Instance.LevelUp ();
			break;

		}
	}

	public void OnClickReplay(){
		Application.LoadLevel ("Main");
	}
}
