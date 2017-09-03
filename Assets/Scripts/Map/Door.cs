using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour, IClickable {

	public Spot spotA, spotB;
	public Transform openSpotA, openSpotB;

	public bool doorOpen;

	public NavMeshObstacle navMeshObstacle;
	public Animator animator;
	public AudioSource audioSource;

	public void MouseOver(Survivor survivor, Item item){
		if(!doorOpen && item != null){
			if((item).canOpenDoor){
				int moveDistanceA = CheckMoveDistance(survivor, spotA);
				int moveDistanceB = CheckMoveDistance(survivor, spotB);
				int moveDistance;
				if(moveDistanceA < moveDistanceB){
					moveDistance = moveDistanceA;
				} else {
					moveDistance = moveDistanceB;
				}
				if(moveDistance <= survivor.action.GetRemainingMoveActions()){
					int actionsUsedOnMovement = moveDistance - survivor.action.GetRemainingMoveOnlyActions();
					if(actionsUsedOnMovement < survivor.action.GetRemainingActions()){
						Cursor.SetCursor(item.mouseCursorActiveImage,Vector2.zero,CursorMode.Auto);
					}
				} else {
					Cursor.SetCursor(null,Vector2.zero,CursorMode.Auto);
				}
			}
		}
	}

	public void OnClick(Survivor survivor, Item item){
		if(!doorOpen && item != null){
			if(item.canOpenDoor){
				int moveDistanceA = CheckMoveDistance(survivor, spotA);
				int moveDistanceB = CheckMoveDistance(survivor, spotB);
				Spot moveSpot;
				int moveDistance;
				if(moveDistanceA < moveDistanceB){
					moveSpot = spotA;
					moveDistance = moveDistanceA;
				} else {
					moveSpot = spotB;
					moveDistance = moveDistanceB;
				}
				if(moveDistance <= survivor.action.GetRemainingMoveActions()){
					int actionsUsedOnMovement = moveDistance - survivor.action.GetRemainingMoveOnlyActions();
					if(actionsUsedOnMovement < survivor.action.GetRemainingActions()){
						survivor.ChangeState(new MoveToDoor(survivor, this, moveSpot, moveDistance));
					}
				}
			}
		}
	}

	int CheckMoveDistance(Survivor survivor, Spot spot){
		List<Spot> path = PathFinding.instance.FindPath(survivor.currentSpot, spot);
		if(path != null){
			return PathFinding.instance.GetPathDistance(path);
		}
		return int.MaxValue;
	}

	public Vector3 FindOpenSpot(Spot spot){
		if(spot == spotA){
			return openSpotA.position;
		} else {
			return openSpotB.position;
		}
	}

	public void OpenDoor () {
		spotA.AddNeighbor(spotB);
		spotB.AddNeighbor(spotA);
		animator.SetTrigger("Open");
		audioSource.PlayOneShot(audioSource.clip);
		navMeshObstacle.enabled = false;
		doorOpen = true;
	}

	void OnDrawGizmosSelected(){
		if(spotA){
			Vector3 _spotA = new Vector3(spotA.transform.position.x, spotA.transform.position.y + 2f, spotA.transform.position.z);
			Gizmos.color = new Color(1f,0f,0f,1f);
			Gizmos.DrawSphere(_spotA,0.5f);
		}
		if(openSpotA){
			Gizmos.DrawSphere(openSpotA.position,0.2f);
		}
		if(spotB){
			Vector3 _spotB = new Vector3(spotB.transform.position.x, spotB.transform.position.y + 2f, spotB.transform.position.z);
			Gizmos.color = new Color(0f,0f,1f,1f);
			Gizmos.DrawSphere(_spotB,0.5f);
		}
		if(openSpotB){
			Gizmos.DrawSphere(openSpotB.position,0.2f);
		}
	}
}
