using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    float PhoneAccelX; //defining a variable to store the phone's X acceleration
    int PhoneAccelCheck;
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

    // Start is called before the first frame update
    void Start()
    {
        AudioClips[1] = bababooey; //assigning each audioclip to a position in the array for random selection in Whip()
        AudioClips[2] = LikeYaCutG;
        AudioClips[3] = TacoBell;
        AudioClips[4] = ass;
        AudioClips[5] = oof;
        AudioClips[6] = baggingarea;
        AudioClips[7] = whip;
        AudioClips[8] = somebody;
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AccelUpdate();
    }

    void AccelUpdate() //handles updating of the PhoneAccel variables
    {
        PhoneAccelX = Input.acceleration.normalized.x;
    }

    void Whip() //handles the checks to actually play the sound, performs the random selection of the sound and adds a point if whipping
    {
        if(PhoneAccelX <= 20)
        {
            SoundChoice = Random.Range(1, 8);
            var ChosenClip = AudioClips[SoundChoice];
            Audio.PlayOneShot(ChosenClip);
        }
    }
}
