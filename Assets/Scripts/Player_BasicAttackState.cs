using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BasicAttackState : EntityState
{
    private float attackVelocityTimer;
    private int comboIndex = 1;
    private int comboMax = 3;
    private float comboResetTime = 0.5f;
    private float lastTimeAttacked;

    public Player_BasicAttackState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        ResetComboAttack();

        anim.SetInteger("basicAttackIndex", comboIndex);

        ApplyAttackVelocity();
    }


    public override void Exit()
    {
        base.Exit();

        comboIndex++;
        lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        HandleAttackVelocity();

        if (triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
    private void ApplyAttackVelocity()
    {
        Vector2 playerAttackVelocity = player.attackVelocity[comboIndex - 1];

        attackVelocityTimer = player.attackVelocityDuration;
        player.SetVelocity(playerAttackVelocity.x * player.facingDir, 0);
    }

    private void HandleAttackVelocity()
    {
        attackVelocityTimer -= Time.deltaTime;
        if (attackVelocityTimer <= 0)
        {
            player.SetVelocity(0, 0);
        }
    }

    private void ResetComboAttack()
    {
        if(Time.time - lastTimeAttacked > comboResetTime)
        {
            comboIndex = 1;
        }

        if (comboIndex > comboMax)
        {
            comboIndex = 1;
        }
    }
}
