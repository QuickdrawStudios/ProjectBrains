using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Door))]
public class DoorEditor : Editor {
	Door door;

	public override void OnInspectorGUI(){
		door = (Door)target;

		DrawDefaultInspector();
		DrawDoorInspector();
	}

	void DrawDoorInspector(){
		GUILayout.Space(10);
		if(GUILayout.Button("Select Neighbors", GUILayout.Height(20))){
			ActiveEditorTracker.sharedTracker.isLocked = true;
		}
		if(GUILayout.Button("Add Neighbors",GUILayout.Height(20))){
			if(Selection.gameObjects.Length != 2){
				EditorUtility.DisplayDialog("Error","A door can only connect 2 spots. Please select only 2 spots.","Continue");
			} else {
				if(Selection.gameObjects[0].tag == "Spot" && Selection.gameObjects[1].tag == "Spot"){
					Undo.RecordObject(door, "Undo add neighbor");
					door.spotA = Selection.gameObjects[0].GetComponent<Spot>();
					Undo.RecordObject(door, "Undo add neighbor");
					door.spotB = Selection.gameObjects[1].GetComponent<Spot>();
					ActiveEditorTracker.sharedTracker.isLocked = false;
				} else {
					Selection.activeGameObject = door.gameObject;
					EditorUtility.DisplayDialog("Error","A door can only connect 2 spots. Please select only 2 spots.","Continue");
				}
			}
		}
		if(GUILayout.Button("Swap Neighbors", GUILayout.Height(20))){
			Spot tempSpot = door.spotA;
			Undo.RecordObject(door, "Undo Neighbor Swap");
			door.spotA = door.spotB;
			door.spotB = tempSpot;
			Selection.activeGameObject = door.gameObject;
		}
	}
}
