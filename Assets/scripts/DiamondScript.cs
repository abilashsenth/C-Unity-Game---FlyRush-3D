using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour
{
    public GameObject diamond;
    public PlayScoreScript playScoreScript;
    // Start is called before the first frame update
    void Start()
    {
       // diamond = GetComponent<GameObject>();
       // plusOne.SetActive(false);
        //playScoreScript = GetComponent<PlayScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //plusOne.SetActive(true);
        diamond.SetActive(false);
        //anim.enabled = true;
        Debug.LogError("diamondCollision");
        playScoreScript.diamondCollision();
    }
}
