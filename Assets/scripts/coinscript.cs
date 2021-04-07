using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinscript : MonoBehaviour
{

    public GameObject plusOne, coin;
    public Animator anim;
    public PlayScoreScript playScoreScript;
    // Start is called before the first frame update
    void Start()
    {
        plusOne.SetActive(false);
        //playScoreScript = GetComponent<PlayScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        plusOne.SetActive(true);
        coin.SetActive(false);
        anim.enabled = true;
        Debug.LogError("coincollision");
        playScoreScript.coinCollision();
    }
}
