using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipUI : MonoBehaviour
{
    public TMP_Text nameText; // Assign in the Inspector
    public TMP_Text descriptionText; // Assign in the Inspector

    public void SetTooltip(string name, string description)
    {
        nameText.text = name;
        descriptionText.text = description;
    }

}
