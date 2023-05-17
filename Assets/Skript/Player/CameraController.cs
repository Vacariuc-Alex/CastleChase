using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 distance;
    public float smoothSpeed = 0.15f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        distance = transform.position - player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + distance;
        transform.position = Vector3.Lerp(transform.position, desiredPosition ,smoothSpeed);

        /*float hInput = Input.GetAxis("Horizontal");
        if (hInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
        }*/
    }
}
