using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float updateTimer = 0.0f;

    public float CurrentTime
    {
        get{
            return updateTimer;
        }
    }

	// Use this for initialization

	void Start () {
        string formatText = System.String.Format("UpdateTimer: {0}", (int)updateTimer); 
        timerText.text = formatText;
	}
	
	// Update is called once per frame
	void Update () {
        updateTimer += Time.deltaTime;
        string text =  ""+(int)updateTimer;
        timerText.text = text;
    }

}
