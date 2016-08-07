using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
public class GameOverPanel : SingletonMonoBehaviour<GameOverPanel>{

	RectTransform rectTransform;
	Vector2 initialPosition;
	public float tweenTime = 0.5f;

	void Start () {
		this.rectTransform = this.GetComponent<RectTransform> ();
		initialPosition = rectTransform.anchoredPosition;
		this.rectTransform.anchoredPosition = Vector2.up * 500;
	}

	public void Show(){
		this.rectTransform.DOAnchorPos (initialPosition, tweenTime);
	}
}
