using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class paperplanescript : MonoBehaviour
{

    public float m_speed = 1.0f;
    float extraSpeed = 0.2f;


    public float rotateBack = 2f;
    public float turnfactor = 10f;
    public float rotation_damping = 10f;
    public float clampX1 = -5f;
    public float clampX2 = 5f;
    public float distanceFromGround = 5f;

    public float altitudeFactor = 10f;


    private float lastMousePoint = 0f;
    private float currentMousePoint = 0f;


    public GameObject endPoint;
    public float xInitial, xFinal;
    private Vector3 rotationVectorVertical;
    Rigidbody mRigidbody;

    void Start()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("currentLevel", sceneIndex);
        mRigidbody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        //mRigidbody.MovePosition(mRigidbody.transform.position + Vector3.forward * m_speed*Time.deltaTime);
        //mRigidbody.velocity = transform.forward * m_speed*Time.deltaTime*timeMultiple;
        Vector3 endPointPos = endPoint.transform.position;
        Vector3 posi = transform.position;
        posi.z = transform.position.z + (endPointPos.z) * Time.deltaTime * m_speed;
        transform.position = new Vector3(transform.position.x, transform.position.y, posi.z);

        //transform.position = Vector3.MoveTowards(transform.position, endPoint.transform.position, m_speed);

        if (Input.GetMouseButtonDown(0))
        {

            lastMousePoint = Input.mousePosition.x;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            lastMousePoint = 0f;
            Debug.Log("MOUSEUP");
            //transform rotation straight            
            StartCoroutine(AnimateRotationTowards(this.transform, Quaternion.identity, rotateBack));

        }

        if (lastMousePoint != 0f)
        {
            currentMousePoint = Input.mousePosition.x ;
            float difference = currentMousePoint - lastMousePoint;
             Debug.Log(difference);
           // Vector3 x = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(transform.position.x + (difference * Time.deltaTime*turnfactor) , clampX1, clampX2) ;

            Vector3 newPosition = new Vector3(pos.x, transform.position.y, transform.position.z);
            transform.position = newPosition;
           

            //lastMousePoint = Input.mousePosition.x * Time.deltaTime;
            if (difference > 0)
            {
                //right animation
                Vector3 rotationVector = transform.rotation.eulerAngles;
                rotationVector.z = -25;
                rotationVector.y = 6;
                rotationVector.x = 0;
               transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotationVector), Time.deltaTime * rotation_damping);
            }
            else if(difference <0)
            {
                //left animation
                Vector3 rotationVector = transform.rotation.eulerAngles;
                rotationVector.z = 25;
                rotationVector.y = -6;
                rotationVector.x = 0;

                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotationVector), Time.deltaTime * rotation_damping);
            }

        }
        rotationVectorVertical = transform.rotation.eulerAngles;

    }
    

   
    private System.Collections.IEnumerator AnimateRotationTowards(Transform target, Quaternion rot, float dur)
    {
        float t = 0f;
        Quaternion start = target.rotation;
        while (t < dur)
        {
            target.rotation = Quaternion.Slerp(start, rot, t / dur);
            yield return null;
            t += Time.deltaTime;
        }
        target.rotation = rot;
    }


    float increaseHeight, decreaseHeight;
    private void FixedUpdate()
    {
        //raycast down
        Vector3 downwards = transform.TransformDirection(Vector3.down);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, downwards, out hit))
        {
            float distToGround = hit.distance;
            levelGround(distToGround);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
        }

    }
    private void levelGround(float distToGround)
    {
        // Debug.Log(distToGround);

        if (distToGround < distanceFromGround)
        {
            increaseHeight = distanceFromGround - distToGround;
            Vector3 pos = transform.position;
            pos.y = transform.position.y + (increaseHeight* Time.deltaTime * altitudeFactor);
            Vector3 newPositionAlt = new Vector3(transform.position.x, pos.y, transform.position.z);
            transform.position = newPositionAlt;
        }
        else if (distToGround > distanceFromGround)
        {
            decreaseHeight = distToGround - distanceFromGround;
            Vector3 pos = transform.position;
            pos.y = transform.position.y - (decreaseHeight * Time.deltaTime * altitudeFactor);
            Vector3 newPositionAlt = new Vector3(transform.position.x, pos.y, transform.position.z);
            transform.position = newPositionAlt;

        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "speedramp")
        {

            StartCoroutine("speedRampEnabled");
        }
    }

    IEnumerator speedRampEnabled()

    {
        m_speed = m_speed + extraSpeed;
        yield return new WaitForSeconds(3);
        m_speed = m_speed - extraSpeed;
    }




}
