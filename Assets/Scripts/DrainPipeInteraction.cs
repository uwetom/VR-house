using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainPipeInteraction : MonoBehaviour
{
     private GameController gt;
     private Material gutterMaterial;
     public Material SelectedGutterMaterial;

     public bool itemFound = false;
     
    // Start is called before the first frame update
    void Start()
    {
        gt = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gutterMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrainPipeHover(){
        //Debug.Log("Drain Pipe hover");
        
        if(!itemFound){
            GetComponent<Renderer>().material = SelectedGutterMaterial;
        }
    }

    public void DrainPipeExitHover(){
        //Debug.Log("Drain Pipe exit");
        
        if(!itemFound){
            GetComponent<Renderer>().material = gutterMaterial;
        }
    }

    public void DrainPipeSelected(){
      
        if(!itemFound){
            gt.gutterFound();

            GetComponent<AudioSource>().Play();
            itemFound = true;

            GetComponent<Renderer>().material = SelectedGutterMaterial;
        }
    }
}
