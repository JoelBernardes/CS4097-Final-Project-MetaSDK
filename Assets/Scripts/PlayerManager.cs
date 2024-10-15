using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manages the item being heled by the player as well as the state
// of the players controllers
public class PlayerManager : MonoBehaviour
{

    private static bool itemHeld = false;

    private void Update()
    {
        Debug.Log(itemHeld);
    }


    public static void SetItemHeld(bool held)
    {
        itemHeld = held;
    }

    public static bool IsItemHeld()
    {
        return itemHeld;
    }
}
