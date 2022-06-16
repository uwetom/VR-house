using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardInteraction : MonoBehaviour
{
    
    private GameController gt;
    // Start is called before the first frame update
    void Start()
    {
        gt = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    
    public void ResetButtonClicked(){
        gt.resetGame();
    }

      public void StartButtonClicked(){
        gt.startSurvey();
    }


}
