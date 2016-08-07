using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraTween : MonoBehaviour {

	// 最後にゲームのカメラを入れること
	public Camera[] cameras;

	public Vector3 returnPos;
	public Vector3 returnRot;

	public float[] tweenTimes;

	void Start () {
		Debug.Log ("カメラTween");
		int gameCameraIndex = cameras.Length - 1;

		// 戻り位置を覚えておく
		returnPos = cameras[gameCameraIndex].transform.position;
		returnRot = cameras[gameCameraIndex].transform.localRotation.eulerAngles;

		// 初期位置へ
		cameras[gameCameraIndex].transform.position = cameras[0].transform.position;
		cameras[gameCameraIndex].transform.localRotation = cameras[0].transform.localRotation;

		// 位置Tween
		var seqPos = DOTween.Sequence();
		seqPos.Append (cameras[gameCameraIndex].transform.DOMove (cameras[0].transform.position, tweenTimes[0])); // ちょっとまつ
		seqPos.Append (cameras[gameCameraIndex].transform.DOMove (cameras[1].transform.position, tweenTimes[1]));
		seqPos.Append (cameras[gameCameraIndex].transform.DOMove (cameras[2].transform.position, tweenTimes[2]));
		seqPos.Append (cameras[gameCameraIndex].transform.DOMove (returnPos, tweenTimes[3]));

		// 回転Tween
		var seqRot = DOTween.Sequence();
		seqRot.Append (cameras[gameCameraIndex].transform.DOLocalRotate(cameras[0].transform.localRotation.eulerAngles, tweenTimes[0], RotateMode.Fast)); // ちょっとまつ
		seqRot.Append (cameras[gameCameraIndex].transform.DOLocalRotate(cameras[1].transform.localRotation.eulerAngles, tweenTimes[1], RotateMode.Fast));
		seqRot.Append (cameras[gameCameraIndex].transform.DOLocalRotate(cameras[2].transform.localRotation.eulerAngles, tweenTimes[2], RotateMode.Fast));
		seqRot.Append (cameras[gameCameraIndex].transform.DOLocalRotate(returnRot, tweenTimes[3], RotateMode.Fast)).OnComplete(OnCompleteTween);

	}

	public void OnCompleteTween(){
		// ゲーム開始
		BallShooter.Instance.StartShoot ();
	}

	void Update () {
	
	}
}
