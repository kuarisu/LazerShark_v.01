﻿using UnityEngine;
using System.Collections;


using UnityEngine;
using System.Collections;
public class Move_Shark_Two : MonoBehaviour 

{
    public GameObject RightForce;
    public GameObject LeftForce;
    private int speedForce = 275;
    private float coolDown = 0.6f;
    private bool moveOKleft = true;
    private bool moveOKright = true;
    //public Animator AnimShark;


    void Update()
    {
        if (Input.GetKeyUp("s") && moveOKleft)
        {
            StartCoroutine(LeftMovement());
        }
        if (Input.GetKeyUp("q") && moveOKright)
        {
            StartCoroutine(RightMovement());
        }

    }

    //Coroutine ajout force à gauche du Player_One
    IEnumerator LeftMovement()
    {

        moveOKleft = false;
        GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * speedForce, LeftForce.transform.localPosition);
        yield return new WaitForSeconds(coolDown);
        moveOKleft = true;

    }

    //Coroutine ajout force à droite du PLayer_One et l'eau
    IEnumerator RightMovement()
    {

        moveOKright = false;
        GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * speedForce, RightForce.transform.localPosition);
        yield return new WaitForSeconds(coolDown);
        moveOKright = true;

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DeathZone")
        {
            Destroy(gameObject);
            Debug.Log("You died player 2");
        }

        if (col.gameObject.tag == "laser")
        {
            StartCoroutine(Immobilisation());
        }
    }


    IEnumerator Immobilisation()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        yield return new WaitForSeconds(2);

    }
}
