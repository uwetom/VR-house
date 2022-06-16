using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject drainpipe;
    public GameObject dampWall;
    private GameObject player;
    private Vector3 startLocation;
    private Quaternion startRotation;
    private int foundIssues = 0;
    private int totalIssues = 2;
    // Start is called before the first frame update
    private enum gameStates { START, SURVEY, END };
    private gameStates currentGameState = gameStates.START;
    private GameObject startCanvas;
    private GameObject surveyCanvas;
    private GameObject endCanvas;
    private GameObject timerTextBox;

    private GameObject EndtimerTextBox;

    private float counter = 0;

    void Start()
    {
        //get player initial location
        player = GameObject.FindGameObjectWithTag("Player");
        startLocation = player.transform.position;
        startRotation = player.transform.rotation;

        startCanvas = GameObject.FindGameObjectWithTag("startCanvas");
        surveyCanvas = GameObject.FindGameObjectWithTag("surveyCanvas");
        endCanvas = GameObject.FindGameObjectWithTag("endCanvas");

        // surveyCanvas.SetActive(false);
        surveyCanvas.GetComponent<Canvas>().enabled = false;
        endCanvas.GetComponent<Canvas>().enabled = false;

        timerTextBox = GameObject.FindGameObjectWithTag("TimmerText");
        EndtimerTextBox = GameObject.FindGameObjectWithTag("endTimmerText"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGameState == gameStates.SURVEY)
        {
            //add to counter
            counter += Time.deltaTime;
            float floorCounter = Mathf.Floor(counter);
            
            timerTextBox.GetComponent<TextMeshProUGUI>().text = floorCounter.ToString() + " Seconds";
        }
    }

    public void resetGame()
    {
        counter = 0;

        foundIssues = 0;

        //reset player
        player.transform.SetPositionAndRotation(startLocation, startRotation);

        GameObject causeText = GameObject.FindGameObjectWithTag("cause_1");
        causeText.GetComponent<TextMeshProUGUI>().text = "?";

        GameObject faultText = GameObject.FindGameObjectWithTag("fault_1");
        faultText.GetComponent<TextMeshProUGUI>().text = "?";

        Toggle toggle1 = GameObject.FindGameObjectWithTag("check_1").GetComponent<Toggle>();
        toggle1.isOn = false;

        Toggle toggle2 = GameObject.FindGameObjectWithTag("check_2").GetComponent<Toggle>();
        toggle2.isOn = false;

        //reset textures

        //surveyCanvas.SetActive(false);
        surveyCanvas.GetComponent<Canvas>().enabled = false;
        // startCanvas.SetActive(true);
        startCanvas.GetComponent<Canvas>().enabled = true;
        endCanvas.GetComponent<Canvas>().enabled = false;

        drainpipe.GetComponent<DrainPipeInteraction>().Reset();
        dampWall.GetComponent<DampInteraction>().Reset();

        currentGameState = gameStates.START;
    }


    public void gutterFound()
    {
        Debug.Log("broken gutter found");

        foundIssues += 1;

        //show found on canvas

        GameObject causeText = GameObject.FindGameObjectWithTag("cause_1");
        causeText.GetComponent<TextMeshProUGUI>().text = "Broken Gutter";

        Toggle toggle1 = GameObject.FindGameObjectWithTag("check_2").GetComponent<Toggle>();
        toggle1.isOn = true;

        checkedIfAllFound();

    }


    public void dampFound()
    {
        Debug.Log("damp found");

        foundIssues += 1;

        //show found on canvas

        GameObject causeText = GameObject.FindGameObjectWithTag("fault_1");
        causeText.GetComponent<TextMeshProUGUI>().text = "Damp on walls";

        Toggle toggle2 = GameObject.FindGameObjectWithTag("check_1").GetComponent<Toggle>();
        toggle2.isOn = true;

        checkedIfAllFound();

    }

    public void startSurvey()
    {
        //  surveyCanvas.SetActive(true);
        surveyCanvas.GetComponent<Canvas>().enabled = true;
        //  startCanvas.SetActive(false);
        startCanvas.GetComponent<Canvas>().enabled = false;

        currentGameState = gameStates.SURVEY;
    }


    private void checkedIfAllFound()
    {
        if (foundIssues >= 2){
            //all issues found, end round;

            currentGameState = gameStates.END;

            surveyCanvas.GetComponent<Canvas>().enabled = false;
            startCanvas.GetComponent<Canvas>().enabled = false;
            endCanvas.GetComponent<Canvas>().enabled = true;


            float floorCounter = Mathf.Floor(counter);
            
            EndtimerTextBox.GetComponent<TextMeshProUGUI>().text = floorCounter.ToString();

        }
    }
}
