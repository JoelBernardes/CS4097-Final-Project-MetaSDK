using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SongPlayerManager : MonoBehaviour
{
    public TMP_Text songName;
    public Image songArt;
    public TMP_Text musicTimeStamp;
    public TMP_Text musicTimeLeft;
    public Button playPauseButton;
    public Slider timeBar;
    public AudioSource musicPlayer;
    float songTime;
    float timeLeft;

    public List<Songs> playlist;
    int currentTrack = 0;

    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        songArt.sprite = playlist[currentTrack].musicArt;
        musicPlayer.clip = playlist[currentTrack].clip;
        musicPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        songName.text = musicPlayer.clip.name;
        //Debug.Log("Song Time: " + musicPlayer.time);
        songTime = musicPlayer.time;
        int songTimeMinutes = Mathf.FloorToInt(songTime / 60);
        int songTimeSeconds = Mathf.FloorToInt(songTime - songTimeMinutes * 60f);
        string songTimeText = string.Format("{0:00}:{1:00}", songTimeMinutes, songTimeSeconds);
        musicTimeStamp.text = songTimeText;
        timeLeft = musicPlayer.clip.length - songTime;
        //Debug.Log("Time left: " + timeLeft);
        int timeLeftMinutes = Mathf.FloorToInt(timeLeft / 60);
        int timeLeftSeconds = Mathf.FloorToInt(timeLeft - timeLeftMinutes * 60f);
        string timeLeftText = string.Format("{0:00}:{1:00}", timeLeftMinutes, timeLeftSeconds);
        musicTimeLeft.text = timeLeftText;
        if (timeLeft > 0)
        {
            timeBar.value = (songTime / musicPlayer.clip.length);
        }
        else
        {
            nextSong();
        }
    }

    public void replaySong()
    {
        musicPlayer.Stop();
        if (musicPlayer.time >= 3f || currentTrack == 0) //replay current track
        {
            if (isPaused)
            {
                playPauseButton.GetComponent<ChangeImage>().changeImageSprite();
                isPaused = false;
            }
        } else
        {
            currentTrack -= 1;
            if (isPaused)
            {
                playPauseButton.GetComponent<ChangeImage>().changeImageSprite();
                isPaused = false;
            }
        }
        songArt.sprite = playlist[currentTrack].musicArt;
        musicPlayer.clip = playlist[currentTrack].clip;
        musicPlayer.Play();
    }
    public void pauseMusic()
    {
        if (isPaused)
        {
            musicPlayer.Play();
            isPaused = false;
        } else
        {
            musicPlayer.Pause();
            isPaused = true;
        }
    }

    public void nextSong()
    {
        musicPlayer.Stop();
        Debug.Log(playlist.Count);
        if (currentTrack == playlist.Count - 1)
        {
            currentTrack = 0;
            if (isPaused)
            {
                playPauseButton.GetComponent<ChangeImage>().changeImageSprite();
                isPaused = false;
            }
        } else
        {
            currentTrack += 1;
            if (isPaused)
            {
                playPauseButton.GetComponent<ChangeImage>().changeImageSprite();
                isPaused = false;
            }
        }
        songArt.sprite = playlist[currentTrack].musicArt;
        musicPlayer.clip = playlist[currentTrack].clip;
        musicPlayer.Play();
    }
}
