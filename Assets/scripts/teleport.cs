using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public GameObject paperPlane;
    public GameObject endPortalPoint;

    private void OnTriggerEnter(Collider other)
    {
        paperPlane.transform.position = endPortalPoint.transform.position;
    }


}
