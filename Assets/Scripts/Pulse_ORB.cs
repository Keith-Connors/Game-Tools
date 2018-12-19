using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse_ORB : MonoBehaviour 
    {

    [SerializeField] private Light HandOrb;
    [SerializeField] private float PULSE_SPEED = 3, PULSE_RANGE = 4, PULSE_MINIMUM = 1;
	
	// Update is called once per frame
	void Update ()
    {
        HandOrb.range = Mathf.PingPong(Time.time * PULSE_SPEED, PULSE_RANGE - PULSE_MINIMUM);
    }
}
