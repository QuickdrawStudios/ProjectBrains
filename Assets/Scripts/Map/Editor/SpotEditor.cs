using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Spot))]
public class SpotEditor : Editor {

	Spot spot;

	public override void OnInspectorGUI(){
		spot = (Spot)target;

		DrawDefaultInspector();
		DrawNeighborsInspector();
	}

	void DrawNeighborsInspector(){
		GUILayout.Space(10);
		if(GUILayout.Button("Select Neighbors", GUILayout.Height(20))){
			ActiveEditorTracker.sharedTracker.isLocked = true;
		}
		if(GUILayout.Button("Add Neighbors",GUILayout.Height(20))){
			foreach(GameObject go in Selection.gameObjects){
				if(go != spot.gameObject){
					if(go.tag == "Spot"){
						Spot addSpot = go.GetComponent<Spot>();
						if(!spot.neighbors.Contains(addSpot)){
							Undo.RecordObject(spot, "Undo add neighbor");
							spot.neighbors.Add(addSpot);
						}
						if(!addSpot.neighbors.Contains(spot)){
							Undo.RecordObject(addSpot, "Undo add neighbor");
							addSpot.neighbors.Add(spot);
						}
					}
				}
			}
			Selection.activeGameObject = spot.gameObject;
			ActiveEditorTracker.sharedTracker.isLocked = false;
		}
	}
}
