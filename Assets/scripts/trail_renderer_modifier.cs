using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trail_renderer_modifier : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        TrailRenderer myTrailRenderer = GetComponent<TrailRenderer>();
        myTrailRenderer.material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
