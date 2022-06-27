using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBalloon : MonoBehaviour
{
    // Start is called before the first frame update

     AudioSource audio;
     
    void Start()
    {
         audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound()
    {
       
        Debug.Log("play_sound!");
            
        if(!audio.isPlaying ){
            audio.Play();
        }

        
    }


}
