﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Class response for taking input from user
/// </summary>
public class InputCounter : SingeltonMonoBehaviour<InputCounter> {

	public event System.Action<int> PlayerTouch = delegate { };

	private IEnumerator _startCountInputs;

	public void StartInputCounter () {
		_startCountInputs = StartCountIEnumerator ();
		StartCoroutine (_startCountInputs);
	}

	public void StopInputCounter () {
		StopCoroutine (_startCountInputs);
	}

	public IEnumerator StartCountIEnumerator () {
		while (true) {

#if UNITY_STANDALONE || UNITY_EDITOR
			if (Input.GetMouseButtonDown (0)) { // for test purpose
				ScoreManager.Instance.PlayerScore++;
				PlayerTouch (ScoreManager.Instance.PlayerScore);
			}
#else
			if (Input.GetTouch (0).phase == TouchPhase.Ended) {
				ScoreManager.Instance.PlayerScore++;
				PlayerTouch (ScoreManager.Instance.PlayerScore);
			}
#endif
			yield return null;
		}
	}
}
