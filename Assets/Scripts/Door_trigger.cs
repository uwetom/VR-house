using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_trigger : MonoBehaviour
{
  
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("door trigger");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            animator.SetBool("open",true);
        }
    }

    private void OnTriggerExit(Collider other) {
         if(other.tag == "Player"){
            animator.SetBool("open",false);
         }
    }
}
