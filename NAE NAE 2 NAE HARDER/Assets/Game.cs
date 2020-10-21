using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    float PhoneAccelX; //defining a variable to store the phone's X acceleration
    int SoundChoice;
    public AudioClip bababooey; //creating AudioClips to store the whip sounds in
    public AudioClip LikeYaCutG;
    public AudioClip TacoBell;
    public AudioClip ass;
    public AudioClip oof;
    public AudioClip baggingarea;
    public AudioClip whip;
    public AudioClip somebody;
    public AudioClip[] AudioClips = new AudioClip[8]; //defining an array to store the audio clips in
    public AudioSource Audio;
    public int Cooldown;

    // Start is called before the first frame update
    void Start()
    {
        AudioClips[0] = bababooey; //assigning each audioclip to a position in the array for random selection in Whip()
        AudioClips[1] = LikeYaCutG;
        AudioClips[2] = TacoBell;
        AudioClips[3] = ass;
        AudioClips[4] = oof;
        AudioClips[5] = baggingarea;
        AudioClips[6] = whip;
        AudioClips[7] = somebody;
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() 
    /***each part of the script is given it's own function starting with an if statement to see if it can run.
    This optimises the code by skipping out on unnecessarily running functions early, resulting in less usage.
    ***/
    {
        Cooldown++; //adds a very short cooldown to prevent multiple sounds on a swing
        PhoneAccelX = 0;
        if(Cooldown >= 35)
        {
            AccelUpdate();
            Whip();
            //Debug.Log("Cooldown's working.");
        }
    }

    void AccelUpdate() //handles updating of the PhoneAccel variables
    {
        PhoneAccelX = Input.acceleration.x; //grabs whatever the accelerometer is reading on the X axis
        //Debug.Log("Acceleration is grabbed.");
        //if(Input.GetKeyDown(KeyCode.Space)) //For PC testing to make sure Whip() functions before accelerometer testing
        //{
        //    PhoneAccelX = 20;
        //}
    }

    void Whip() //handles the checks to actually play the sound and performs the random selection of the sound.
    {
        if(PhoneAccelX >= 5.0f || PhoneAccelX <= -5.0f)
        {
            SoundChoice = Random.Range(0, 7); //chooses a random number between 0 and 7
            var ChosenClip = AudioClips[SoundChoice]; //uses a generic var to grab the audioclip chosen by the previous line
            Audio.PlayOneShot(ChosenClip); //plays the chosen audio clip
            Handheld.Vibrate();
            Cooldown = 0;
        }
    }
}
