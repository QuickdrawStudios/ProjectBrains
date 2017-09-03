//STILL NEED TO ADD LERP TO ZOOM

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{

    public static Cam instance;
    public Transform cameraTransform;

    private Vector3 startPosition;
    private Vector3 startRotation;

    public float rotationSpeed, camSpeed;

    public float heightScale = 1f;
    public float widthScale = 1f;

    public float xScale = 0.5F;
    public float yScale = 0.5F;

	public Camera mainCamera;
	public Camera secondCamera;
	public float zoomMax, zoomMin;
	float targetZoom;

	Transform camTarget;
    Vector3 targetRotation;
    bool camDown;

    public bool camRotating;

    void Awake() {
        instance = this;
        startPosition = cameraTransform.localPosition;
        startRotation = cameraTransform.localRotation.eulerAngles;
        targetRotation = transform.rotation.eulerAngles;
        camTarget = transform;
        targetZoom = mainCamera.fieldOfView;
	}

    void Update(){
        CamMotion();

        ZoomInput();

        RotationInput();

        CamMove();

        if((int)transform.rotation.eulerAngles.y == (int)targetRotation.y && camRotating){
        	StopRotating();
        }
    }

	void CamMotion(){
        float height = Mathf.PerlinNoise(Time.time * xScale, 0.0F) - 0.5f;
        float width = Mathf.PerlinNoise(0.0F, Time.time * yScale) - 0.5f;

        Vector3 pos = startPosition;
        pos += heightScale * height * cameraTransform.up;
        pos += heightScale * width * cameraTransform.right;
        cameraTransform.localPosition = pos;

        Vector3 posR = startRotation;
        posR.y += heightScale * height;
        posR.x += heightScale * width;

        cameraTransform.localRotation = Quaternion.Euler(posR);
    }

    public void RotationInput()
    {
    	if(Input.GetMouseButton(2)){
			targetRotation = transform.rotation.eulerAngles + Vector3.up * Input.GetAxis("Mouse X") * 2f + Vector3.forward * Input.GetAxis("Mouse Y") * -2f;
    	}
	}

	void ZoomInput(){
		if(Input.GetAxis("Mouse ScrollWheel") > 0f){
			targetZoom -= 20f;
			if(targetZoom < zoomMin){
				targetZoom = zoomMin;
			}
		} else if(Input.GetAxis("Mouse ScrollWheel") < 0f){
			targetZoom += 20f;
			if(targetZoom > zoomMax){
				targetZoom = zoomMax;
			}
		}
    }

    void CamMove(){
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * rotationSpeed);
		transform.position = Vector3.MoveTowards(transform.position, camTarget.position, Time.deltaTime * camSpeed);

		mainCamera.fieldOfView = targetZoom;
		secondCamera.fieldOfView = targetZoom;
    }

    void StopRotating(){
       	camRotating = false;
    }

    public void LookAt(Transform lookTarget) {
        camTarget = lookTarget;
    }
}
