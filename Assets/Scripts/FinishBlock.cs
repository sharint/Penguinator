using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBlock : MonoBehaviour
{
    //public bool isFinish;

    GameObject trigger;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        trigger = new GameObject("Trigger");
        trigger.AddComponent<Block>();
        trigger.AddComponent<BoxCollider>().isTrigger = true;
        trigger.AddComponent<Rigidbody>().useGravity = false;
        trigger.transform.position = transform.position;
    }

}
