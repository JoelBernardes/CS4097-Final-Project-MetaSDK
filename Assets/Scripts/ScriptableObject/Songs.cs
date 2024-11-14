using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Song", menuName = "Song")]
public class Songs : ScriptableObject
{
    public AudioClip clip;
    public Sprite musicArt;
}
