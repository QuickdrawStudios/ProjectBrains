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

	public Transform zoomTransform;
	Vector3 zoomTarget;

	Transform camTarget;
    Vector3 targetRotation;
    bool camDown;

    public bool camRotating;

    CamDirection camDirection;

	public enum CamDirection
	{
		FRONT,
		LEFT,
		RIGHT,
		BACK
	}
    void Awake() {
        instance = this;
        startPosition = cameraTransform.localPosition;
        startRotation = cameraTransform.localRotation.eulerAngles;
        targetRotation = transform.rotation.eulerAngles;
        camTarget = transform;
        camDirection = CamDirection.FRONT;
        zoomTarget = zoomTransform.localPosition;
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
			targetRotation = transform.rotation.eulerAngles + Vector3.up * Input.GetAxis("Mouse X") * 2f;
    	}
    	/*
        if (!camRotating ) {
            if (Input.GetKeyDown(KeyCode.LeftArrow)){
                targetRotation = targetRotation + Vector3.up * 90;
				camRotating = true;
				switch(camDirection){
				case CamDirection.FRONT:
					camDirection = CamDirection.RIGHT;
					break;
				case CamDirection.RIGHT:
					camDirection = CamDirection.BACK;
					break;
				case CamDirection.BACK:
					camDirection = CamDirection.LEFT;
					break;
				case CamDirection.LEFT:
					camDirection = CamDirection.FRONT;
					break;
				}
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                targetRotation = targetRotation + Vector3.up * -90;
				camRotating = true;
				switch(camDirection){
				case CamDirection.FRONT:
					camDirection = CamDirection.LEFT;
					break;
				case CamDirection.RIGHT:
					camDirection = CamDirection.FRONT;
					break;
				case CamDirection.BACK:
					camDirection = CamDirection.RIGHT;
					break;
				case CamDirection.LEFT:
					camDirection = CamDirection.BACK;
					break;
				}
			}

		}
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ){
            if (camDown) {
                targetRotation = targetRotation + Vector3.right * 30;
                camDown = false;
            } else { 
                targetRotation = targetRotation + Vector3.right * -30;
                camDown = true;
            }
		}

        targetRotation.y = (targetRotation.y + 360) % 360.0f;
        */
	}

	void ZoomInput(){
		if(Input.GetAxis("Mouse ScrollWheel") > 0f){
			if(Vector3.Distance(zoomTransform.position + zoomTransform.forward * 2f, camTarget.position) > 2f){
				zoomTarget = zoomTransform.localPosition + zoomTransform.forward * 2f;
        	}
		} else if(Input.GetAxis("Mouse ScrollWheel") < 0f){
			if(Vector3.Distance(zoomTransform.position - zoomTransform.forward * 2f, camTarget.position) < 16f){
				zoomTarget = zoomTransform.localPosition - zoomTransform.forward * 2f;
			}
		}
    }

    void CamMove()
    {
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * rotationSpeed);
		transform.position = Vector3.MoveTowards(transform.position, camTarget.position, Time.deltaTime * camSpeed);

		zoomTransform.localPosition = Vector3.MoveTowards(zoomTransform.localPosition, zoomTarget, Time.deltaTime * camSpeed);
    }

    void StopRotating(){
       	camRotating = false;
    }

    public void LookAt(Transform lookTarget) {
        camTarget = lookTarget;
    }

    void OnDrawGizmos(){
    	Gizmos.color = Color.red;
		Gizmos.DrawLine(zoomTransform.position, zoomTransform.position + zoomTransform.forward * 100f);
    }
}
