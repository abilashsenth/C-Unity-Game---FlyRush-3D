using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkerend : MonoBehaviour
{
    public TimeManager timeManager;
    private void OnTriggerEnter(Collider other)
    {
        timeManager.stopTime();
    }
}
