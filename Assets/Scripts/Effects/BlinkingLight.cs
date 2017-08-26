using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour {
	Light _light;
	public float blinkTime;
	float blinkTimer;
	bool lightOn;
	// Use this for initialization
	void Start () {
		_light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if(blinkTimer > 0){
			blinkTimer -= Time.deltaTime;
		} else {
			blinkTimer = blinkTime;
			if(lightOn){
				_light.enabled = false;
			} else {
				_light.enabled = true;
			}
			lightOn = !lightOn;
		}
	}
}
