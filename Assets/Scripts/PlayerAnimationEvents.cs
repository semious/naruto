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

    private void StartAttack()
    {
        player.setMovement(false);
        player.setAttack(true);
    }

    private void FinishAttack()
    {
        player.setMovement(true);
        player.setAttack(false);
    }

    private void Damage() { 
        player.DamanageEnemies();
    }

    
}
