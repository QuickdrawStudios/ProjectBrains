using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Spots {

	public static float GetDistance(Spot startSpot, Spot endSpot){
		return Vector3.Distance(startSpot.transform.position, startSpot.transform.position);
	}

}
