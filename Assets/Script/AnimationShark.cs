using UnityEngine;
using System.Collections;

public class AnimationShark : MonoBehaviour {

    public Animator AnimShark;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Water")
        {
            AnimShark.SetBool("inWater", true);
            Debug.Log(AnimShark.GetBool("inWater"));

        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Water")
        {
            AnimShark.SetBool("inWater", false);
            Debug.Log(AnimShark.GetBool("inWater"));
        }
    }
}
