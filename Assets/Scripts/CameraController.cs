using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField, Min(0f)] private float sensivity;
    public string state;
    const float minX = 0f;
    const float maxX = 180f;


    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || state == "Right")
        {
            cam.transform.position += Vector3.right * sensivity * Time.deltaTime;
            if (cam.transform.position.x > maxX)
            {
                cam.transform.position = new Vector3(maxX, cam.transform.position.y, cam.transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || state == "Left")
        {
            cam.transform.position += Vector3.left * sensivity * Time.deltaTime;
            if (cam.transform.position.x < minX)
            {
                cam.transform.position = new Vector3(minX, cam.transform.position.y, cam.transform.position.z);
            }
        }
    }

    public void ChangeHoverState(string newState)
    {
        state = newState;
    }

}
