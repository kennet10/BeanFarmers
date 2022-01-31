using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOT BEING USED, DOES NOT WORK PROPERLY, currently using Cinemachine instead
public class CameraMovement : MonoBehaviour
{
    [SerializeField] float dampTime;
    [SerializeField] float edgeBuffer;
    [SerializeField] float minSize;
    [SerializeField] List<Transform> targets;

    private Camera cam;
    private float zoomSpeed;
    private Vector3 moveVelocity;
    private Vector3 thePos;

    private void Awake()
    {
        cam = GetComponent<Camera>();

        // If the gameObject is disabled, removes it from the targets
        foreach(Transform i in targets) {
            if (!i.gameObject.activeSelf) {
                targets.Remove(i);
            }
        }
    }

    // Updates the camera's location and zoom with the character's movement
    private void FixedUpdate()
    {
        Move();
        Zoom();
    }

    // Sets starting location and zoom
    public void SetStartCam()
    {
        FindAveragePosition();

        transform.position = thePos;

        //cam.fieldOfView = FindRequiredSize();
    }

    // Finds the average position and sets the camera's position to the average location of the players
    private void Move()
    {
        FindAveragePosition();

        transform.position = Vector3.SmoothDamp(transform.position, thePos, ref moveVelocity, dampTime);
    }

    // Finds the average position between every player in the game
    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        for (int i = 0; i < targets.Count; i++) {
            if (!targets[i].gameObject.activeSelf)
                continue;

            averagePos += targets[i].position;
            numTargets++;
        }

        if (numTargets > 0)
            averagePos /= numTargets;

        averagePos.y = transform.position.y;

        thePos = averagePos;
    }

    // Smoothly changes the FOV to the requiredSize based on zoomSpeed and dampTime
    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        cam.fieldOfView = Mathf.SmoothDamp(cam.fieldOfView, requiredSize, ref zoomSpeed, dampTime);
    }

    // Returns the max size to set the camera to based on the edgeBuffer and the distance of the target position and the local position.
    private float FindRequiredSize()
    {
        Vector3 theLocalPos = transform.InverseTransformPoint(thePos);

        float size = 0f;

        for (int i = 0; i < targets.Count; i++) {
            if (!targets[i].gameObject.activeSelf)
                continue;

            Vector3 targetLocalPos = transform.InverseTransformPoint(targets[i].position);

            Vector3 thePosToTarget = targetLocalPos - theLocalPos;

            size = Mathf.Max(size, Mathf.Abs(thePosToTarget.y));

            size = Mathf.Max(size, Mathf.Abs(thePosToTarget.x) / cam.aspect);
        }

        size += edgeBuffer;

        size = Mathf.Max(size, minSize);

        return size;
    }

}
