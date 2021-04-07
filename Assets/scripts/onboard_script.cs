using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onboard_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject onboardSwipe, onboard1, onboard2, onboard3;
    public TimeManager timeManager;

    void Start()
    {
        onboardSwipe.SetActive(true);
        onboard1.SetActive(false);
        onboard2.SetActive(false);
        onboard3.SetActive(false);
        
        StartCoroutine(disappearOnboardSwipe());

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            onboard1.SetActive(false);
            onboard2.SetActive(false);
            onboard3.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "onboard1")
        {
            onboard1.SetActive(true);
            Time.timeScale = 0.1f;

        }
        else if (other.gameObject.tag == "onboard2")
        {
            onboard2.SetActive(true);
            Time.timeScale = 0.1f;

        }
        else if(other.gameObject.tag == "onboard3")
        {
            onboard3.SetActive(true);
            Time.timeScale = 0.1f;
        }

    }

    public IEnumerator disappearOnboardSwipe()
    {
        //waits for 1 second and executes the following
        yield return new WaitForSeconds(5f);
        onboardSwipe.SetActive(false);
    }
}
