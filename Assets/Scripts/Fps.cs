using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fps : MonoBehaviour
{

	float count;
	public Text textFps;

	IEnumerator Start()
	{
		//GUI.depth = 2;
		while (true)
		{
			if (Time.timeScale == 1)
			{
				yield return new WaitForSeconds(0.1f);
				count = (1 / Time.deltaTime);
				textFps.text = "FPS :" + (Mathf.Round(count));
			}
			else
			{
				//textFps = "Pause";
			}
			yield return new WaitForSeconds(0.5f);
		}
	}
	/*
	void OnGUI()
	{
		GUI.Label(new Rect(5, 40, 100, 25), textFps);
	}*/
}