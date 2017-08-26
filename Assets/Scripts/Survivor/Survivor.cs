using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Survivor : MonoBehaviour {

	[HideInInspector]
	public SurvivorInventory inventory;
	[HideInInspector]
	public SurvivorCard card;
	[HideInInspector]
	public SurvivorAction action;
	[HideInInspector]
	public NavMeshAgent navMeshAgent;
	[HideInInspector]
	public Animator animator;

	SurvivorState stateMachine = new SurvivorState();

	public string _name;
	public Sprite characterImage;

	//[HideInInspector]
	public Spot currentSpot;

	void Start(){
		navMeshAgent = GetComponent<NavMeshAgent>();
		navMeshAgent.updatePosition = true;
	}

	void Update(){
		stateMachine.StateUpdate();
	}

	public void ChangeState(IState state){
		stateMachine.ChangeState(state);
	}
}
