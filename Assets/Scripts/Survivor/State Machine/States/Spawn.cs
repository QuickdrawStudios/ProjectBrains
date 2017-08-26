using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : IState {

	Survivor survivor;
	Spot spawnSpot;

	public Spawn(Survivor survivor, Spot spawnSpot){
		this.survivor = survivor;
		this.spawnSpot = spawnSpot;
	}

	public void Enter () {
		if(survivor.currentSpot != null){
			survivor.currentSpot.RemoveOccupant(survivor);
		}
		survivor.currentSpot = spawnSpot;
		if(!spawnSpot.occupants.Contains(survivor)){
			spawnSpot.occupants.Add(survivor);
		}
		survivor.transform.position = spawnSpot.FindStandingSpot();
		survivor.ChangeState(new Idle(survivor));
	}
	
	public void Update () {
		
	}

	public void Exit () {

	}
}
