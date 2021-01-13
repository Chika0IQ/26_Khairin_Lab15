using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{

    public AudioClip[] BGMClipArr;  // BGM array

    private AudioSource bgmSource;  // Initaillize AudioSouce

    private float volume;           // Volume variable 


    // Start is called before the first frame update
    void Start()
    {
        bgmSource = GetComponent<AudioSource>();  // Get AudioSource Component
    }

    // Update is called once per frame
    void Update()
    {
        AudioChange();     // Calling AudioChange Function
        TabKeyPressed();   // Calling TabKeyPressed Function
    }

    private void TabKeyPressed()
    {

        // On tab key pressed,  Bgm will change to a random BGM in the array
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            int rand = Random.Range(0, BGMClipArr.Length);
            bgmSource.PlayOneShot(BGMClipArr[rand]);
        }
    }

    private void AudioChange()
    {

        //Audio will increase or decrease with up or down arrow keys are pressed
        if (Input.GetKey(KeyCode.UpArrow))
        {
            bgmSource.volume = volume+=0.2f * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            bgmSource.volume = volume-=0.2f * Time.deltaTime;
        }
    }
}