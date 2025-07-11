using UnityEngine;

public class Player_AnimationTriggers : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    // This method is called by the Animator when the animation state is triggered
    private void CurrentStateTrigger()
    {
        //Debug.Log("Current State Triggered");
        player.CallAnimationTrigger();
    }
}
