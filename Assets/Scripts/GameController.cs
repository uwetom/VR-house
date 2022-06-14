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


    private GameObject startCanvas;
    private GameObject surveyCanvas;

    void Start()
    {
        //get player initial location
        player = GameObject.FindGameObjectWithTag("Player");
        startLocation = player.transform.position;
        startRotation = player.transform.rotation;

       // startCanvas = GameObject.FindGameObjectWithTag("startCanvas");
      //  surveyCanvas = GameObject.FindGameObjectWithTag("surveyCanvas");

       // surveyCanvas.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {

    }

    public void resetGame()
    {

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

       // surveyCanvas.SetActive(false);
       // startCanvas.SetActive(true);

       drainpipe.GetComponent<DrainPipeInteraction>().Reset();
       dampWall.GetComponent<DampInteraction>().Reset();
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

    }

    public void startSurvey()
    {
        startCanvas.SetActive(false);
        surveyCanvas.SetActive(true);
    }


}
