using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectMovement : MonoBehaviour
{
    public Transform TargetTransform;

    private float xoffset, yoffset, zoffset;
    void Start()
    {
        xoffset = transform.position.x - TargetTransform.position.x;
        yoffset = transform.position.y - TargetTransform.position.y;
        zoffset = transform.position.z - TargetTransform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(
            TargetTransform.position.x + xoffset,
            TargetTransform.position.y + yoffset,
            TargetTransform.position.z + zoffset);
    }
}
