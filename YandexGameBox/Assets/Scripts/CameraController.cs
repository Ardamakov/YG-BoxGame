using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; 

    void LateUpdate()
    {
        transform.position = player.transform.position;
    }
}
