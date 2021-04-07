using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confettiTrigger : MonoBehaviour
{

    public GameObject confetti1, confetti2, confetti3, confetti4, confetti5, confetti6;
    private void Start()
    {
        confetti1.SetActive(false);
        confetti2.SetActive(false);
        confetti3.SetActive(false);
        confetti4.SetActive(false);
        confetti5.SetActive(false);
        confetti6.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        confetti1.SetActive(true);
        confetti2.SetActive(true);
        confetti3.SetActive(true);
        confetti4.SetActive(true);
        confetti5.SetActive(true);
        confetti6.SetActive(true);
    }
}
