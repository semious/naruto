using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    private void enableAttack()
    {
        player.setMovement(false);
        player.setAttack(true);
    }

    private void disableAttack()
    {
        player.setMovement(true);
        player.setAttack(false);
    }
}
