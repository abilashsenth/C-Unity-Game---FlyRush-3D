using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_bouncyball : MonoBehaviour
{

    public GameObject ballOne, ballTwo, ballThree;

    // Start is called before the first frame update
    void Start()
    {
        ballOne.SetActive(false);
        ballTwo.SetActive(false);
        ballThree.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ballOne.SetActive(true);
        ballTwo.SetActive(true);
        ballThree.SetActive(true);
    }
}
