using UnityEngine;
using System.Collections;

public class Move_Shark_One : MonoBehaviour {


    public GameObject RightForce;
    public GameObject LeftForce;
    private int speedForceUp = 275;
    private int speedForceDown = 20;
    private float coolDown = 0.2f;
    private bool moveOKleft = true;
    private bool moveOKright = true;
    private Vector3 LeftPosition;
    private Vector3 RightPosition;
    //public Animator AnimShark;


    void Update()
    {
        if (Input.GetKeyUp("l") && moveOKleft)
        {
            StartCoroutine(LeftMovement());
        }
        if (Input.GetKeyUp("m") && moveOKright)
        {
            StartCoroutine(RightMovement());
        }

        LeftPosition = transform.InverseTransformPoint(LeftForce.transform.position);
        RightPosition = transform.InverseTransformPoint(RightForce.transform.position);
    }

    //Coroutine ajout force à gauche du Player_One
    IEnumerator LeftMovement()
    {
        moveOKleft = false;
        GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * speedForceUp, LeftPosition);
        yield return new WaitForSeconds(coolDown);
        moveOKleft = true;
       

    }

    //Coroutine ajout force à droite du PLayer_One
    IEnumerator RightMovement()
    {

        moveOKright = false;
        GetComponent<Rigidbody>().AddForceAtPosition(Vector3.down * speedForceDown, RightPosition);
        yield return new WaitForSeconds(coolDown);
        moveOKright = true;
       
    }


    //Triger avec la Zone Mortel (mort) et avec le laser (immobilisation) et l'eau
    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "DeathZone")
        {
            Destroy(gameObject);
            Debug.Log("You died player 1");
        }

        if (col.gameObject.tag == "laser")
        {
            Destroy(col.gameObject);
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
