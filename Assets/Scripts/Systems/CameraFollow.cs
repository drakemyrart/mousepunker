using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [Header("Target")]
    public Transform target;
        

    [Header("Distances")]
    [Range(1f, 10f)]public float zoom = 5f;
    public float minZoom = 1f;
    public float maxZoom = 10f;
    public Vector3 offset;
    private float moveDistance = 50f;
   

    [Header("Speeds")]
    public float smoothSpeed = 3f;
    public float scrollSensitivity = 1f;


    // Use this for initialization
    void Awake () {

        //FindObjectOfType< StoryStart > ().TriggerStory();
    }
	
	// Update is called once per frame
	void LateUpdate () {

        if (!target)
        {
            //print("NO CAMERA TARGET");
            return;
        }

        if (Input.GetMouseButton(0))
        {
         transform.RotateAround(target.position, target.up, Input.GetAxis("Mouse X") * smoothSpeed);

        }
                   
        float num = Input.GetAxis("Mouse ScrollWheel");
        zoom -= num * scrollSensitivity;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        ZoomCamera();


        Vector3 pos = target.position + offset;
        pos -= transform.forward * moveDistance;

        transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed * Time.deltaTime);

        

    }

    void ZoomCamera()
    {
        Camera.main.orthographicSize = zoom;
    }

   
}
