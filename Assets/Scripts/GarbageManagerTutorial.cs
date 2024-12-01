using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageManagerTutorial : MonoBehaviour
{
    public int destroyAdvanceToLevel;

    public int restoreAdvanceToLevel;

    public string objectDeletedTag;
    
    bool deleteDone;


    // Update is called once per frame
    void Update()
    {
        if (!deleteDone)
        {
            if (GarbageManager.disabledObjects.Count > 0 && LookForDelete(objectDeletedTag))
            {
                deleteDone = true;
                FindObjectOfType<TutorialManager>().AdvanceLevel(destroyAdvanceToLevel);
            }
        }
        else
        {
            if (!LookForDelete(objectDeletedTag))
            {
                FindObjectOfType<TutorialManager>().AdvanceLevel(restoreAdvanceToLevel);
            }
        }
    }

    bool LookForDelete(string objTag)
    {
        bool found = false;
        foreach (GameObject go in GarbageManager.disabledObjects)
        {
            if (go.tag == objTag)
            {
                found = true;
            }
        }

        return found;
    }
}
