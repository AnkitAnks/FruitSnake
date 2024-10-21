using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamer : MonoBehaviour
{
    public GameObject objectToFollow;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = objectToFollow.transform.position;
        Vector3 rot = objectToFollow.transform.eulerAngles;
        pos.z = pos.z -10;
        pos.y = 10;
        rot.x = 30;
        rot.y = 0;
        rot.z = 0;

        transform.position = pos;
        transform.eulerAngles = rot;

    }
}
