using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationConstraint : MonoBehaviour
{



    void LateUpdate()
    {
            transform.rotation = Quaternion.identity;
    }
}
