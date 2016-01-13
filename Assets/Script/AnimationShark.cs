using UnityEngine;
using System.Collections;

public class AnimationShark : MonoBehaviour {

    public Animator AnimShark;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Water")
        {
            AnimShark.SetBool("inWater", true);

        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Water")
        {
            AnimShark.SetBool("inWater", false);
        }
    }
}
