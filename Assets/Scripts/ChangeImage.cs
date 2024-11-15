using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeImage : MonoBehaviour
{
    Image sprite;
    public Sprite playImage;
    public Sprite pauseImage;
    bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<Image>();
    }

    public void changeImageSprite()
    {
        if (isPaused)
        {
            sprite.sprite = pauseImage;
            isPaused = false;
        } else
        {
            sprite.sprite = playImage;
            isPaused = true;
        }
    }
}
