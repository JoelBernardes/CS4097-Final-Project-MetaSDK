using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Input;


public class HapticFeedback : MonoBehaviour
{

    [Range(0, 2.5f)]
    public float frequency;
    [Range(0, 1)]
    public float amplitude;
    [Range(0, 1)]
    public float duration;

    GrabInteractable grabInteractable;

    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponentInChildren<GrabInteractable>();
        grabInteractable.WhenSelectingInteractorAdded.Action += WhenSelectingInteractorAdded_Action;
    }

    private void WhenSelectingInteractorAdded_Action(GrabInteractor obj)
    {
        ControllerRef controllerRef = obj.GetComponent<ControllerRef>();
        if (controllerRef)
        {
            if (controllerRef.Handedness == Handedness.Right)
            {
                triggerHaptics(OVRInput.Controller.RTouch);
            }
            else
            {
                triggerHaptics(OVRInput.Controller.LTouch);
            }
        }
    }

    private void triggerHaptics(OVRInput.Controller controller)
    {
        StartCoroutine(triggerHapticsRoutine(controller));
    }

    private IEnumerator triggerHapticsRoutine(OVRInput.Controller _controller)
    {
        OVRInput.SetControllerVibration(frequency, amplitude, _controller);
        yield return new WaitForSeconds(duration);
        OVRInput.SetControllerVibration(0, 0, _controller);
    }
}
