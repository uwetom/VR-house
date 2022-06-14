using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipBoard : MonoBehaviour
{
    // Start is called before the first frame update

    GameController gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void startSurvey(){

        //hide this panel and show next
       // GameController gc = GameController.GetComponent<GameController>();
        gameController.startSurvey();
    }
}
