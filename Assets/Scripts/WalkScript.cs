using UnityEngine;
using System.Collections;

public class WalkScript : MonoBehaviour {

    // Use this for initialization
    CharacterController cc;
 void Start () {
        cc = GetComponent<CharacterController>();
 }
 
 // Update is called once per frame
 void Update () {

        Debug.Log(cc.velocity.magnitude);
        if (cc.velocity.magnitude > 1f && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().Play();
        }
 }
}