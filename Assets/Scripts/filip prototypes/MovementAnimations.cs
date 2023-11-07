using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimations : MonoBehaviour
{
    [SerializeField] private Animator bikeAnimator;
    private static readonly int TurnedLeft = Animator.StringToHash("TurnedLeft");
    private static readonly int TurnedRight = Animator.StringToHash("TurnedRight");

    public void TurnLeft()
    {
        bikeAnimator.SetBool(TurnedLeft, true);
    }
    public void TurnRight()
    {
        bikeAnimator.SetBool(TurnedRight, true);
    }

    public void ResetAnimation()
    {
        bikeAnimator.SetBool(TurnedLeft, false);
        bikeAnimator.SetBool(TurnedRight, false);
    }
    // private IEnumerator TurnLeftRoutine()
    // {
    //     yield return new WaitForSeconds(1f);
    //     bikeAnimator.SetBool(TurnedLeft, false);
    // }
    // private IEnumerator TurnRightRoutine()
    // {
    //     yield return new WaitForSeconds(1f);
    //     bikeAnimator.SetBool(TurnedRight, false);
    // }
}
