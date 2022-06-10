using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DampInteraction : MonoBehaviour
{
     private GameController gt;
     private Material originalMaterial;
     public Material SelectedMaterial;

     public bool itemFound = false;
     
    // Start is called before the first frame update
    void Start()
    {
        gt = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        originalMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hover(){
        //Debug.Log("Drain Pipe hover");
        
        if(!itemFound){
            GetComponent<Renderer>().material = SelectedMaterial;
        }
    }

    public void ExitHover(){
       
        if(!itemFound){
            GetComponent<Renderer>().material = originalMaterial;
        }
    }

    public void Selected(){
      
        if(!itemFound){
            gt.dampFound();

            GetComponent<AudioSource>().Play();
            itemFound = true;

            GetComponent<Renderer>().material = SelectedMaterial;
        }
    }
}
