using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    public Transform Target;

    private void LateUpdate()
    {
        transform.LookAt(Target);
    }
}
