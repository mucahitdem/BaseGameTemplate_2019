using System;
using TMPro;
using UnityEngine;

namespace Scripts.BaseGameScripts.Helper
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class FpsDisplay : MonoBehaviour
	{
		[SerializeField]
		public TextMeshProUGUI fpsText;

		private float pollingTime = 1f;
		private float _time;
		private int _frameCount;

		private void OnEnable()
		{
			if (fpsText == null)
				fpsText = GetComponent<TextMeshProUGUI>();
		}

		private void Update()
		{
			_time += Time.deltaTime;
			_frameCount++;

			if (_time >= pollingTime)
			{
				int frameRate = Mathf.RoundToInt(_frameCount / _time);
				fpsText.text = frameRate + " fps";

				_time -= pollingTime;
				_frameCount = 0;
			}
		}
	}
}
