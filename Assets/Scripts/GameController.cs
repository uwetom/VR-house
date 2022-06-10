using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    
    private GameObject player;
    private Vector3 startLocation;
    private Quaternion startRotation; 

    private int foundIssues = 0;
    private int totalIssues = 2;
    // Start is called before the first frame update
    void Start()
    {
        //get player initial location
        player = GameObject.FindGameObjectWithTag("Player");
        startLocation = player.transform.position;
        startRotation =  player.transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetGame(){
       
        //reset player
        player.transform.SetPositionAndRotation(startLocation,startRotation);

          GameObject causeText = GameObject.FindGameObjectWithTag("cause_1");
            causeText.GetComponent<TextMeshProUGUI>().text = "?";
    }


    public void gutterFound(){
        Debug.Log("broken gutter found");

        foundIssues +=1;

        //show found on canvas

        GameObject causeText = GameObject.FindGameObjectWithTag("cause_1");
        causeText.GetComponent<TextMeshProUGUI>().text = "Broken Gutter";
        
    }


     public void dampFound(){
        Debug.Log("damp found");

        foundIssues +=1;

        //show found on canvas

        GameObject causeText = GameObject.FindGameObjectWithTag("fault_1");
        causeText.GetComponent<TextMeshProUGUI>().text = "Damp on walls";
        
    }


}
