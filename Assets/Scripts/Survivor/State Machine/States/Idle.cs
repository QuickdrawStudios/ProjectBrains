using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : IState {

	Survivor survivor;

	public Idle(Survivor survivor){
		this.survivor = survivor;
	}

	public void Enter () {
		survivor.animator.SetBool("Walking", false);
	}

	public void Update(){

	}

	public void Exit () {

	}
}
