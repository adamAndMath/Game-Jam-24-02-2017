using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {
    public float BlinkTime;
    private float TimeUntilNextBlink;
    private SpriteRenderer eyes;
    private bool IsBlinking;
    public float BlinkDuration;
    private float BlinkTimeLeft = 0;
    private bool blink;

	// Use this for initialization
	void Start ()
    {
        eyes = GetComponent<SpriteRenderer>();
        TimeUntilNextBlink = BlinkTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!IsBlinking)
        {
            TimeUntilNextBlink = TimeUntilNextBlink - Time.deltaTime;
        }
        if (TimeUntilNextBlink <= 0)
        {
            IsBlinking = true;
        }
        if (IsBlinking && !blink)
        {
            eyes.enabled = false;
            BlinkTimeLeft = BlinkDuration;
            blink = true;
        }
        if (IsBlinking && blink)
        {
            BlinkTimeLeft = BlinkTimeLeft - Time.deltaTime;
        }
        if (BlinkTimeLeft <= 0 && blink)
        {
            IsBlinking = false;
            blink = false;
            TimeUntilNextBlink = BlinkTime;
            eyes.enabled = true;
        }
             
	}
}
