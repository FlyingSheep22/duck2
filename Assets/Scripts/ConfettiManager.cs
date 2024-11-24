using UnityEngine;

public class ConfettiManager : MonoBehaviour
{
    public ConfettiAnimationScript[] confettiObjects; // Array of existing objects

    public void TriggerConfetti()
    {
        // Activate the confetti animations
        foreach (ConfettiAnimationScript confetti in confettiObjects)
        {
            confetti.callConfetti();
        }
    }
}