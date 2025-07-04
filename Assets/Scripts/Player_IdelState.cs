using UnityEngine;

public class Player_IdelState : EntityState
{
    public Player_IdelState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (player.moveInput.x != 0 || player.moveInput.y != 0)
        {
            // 在切换到其他状态之前，先设置转向,否则会出现其他状态中动画第一帧突然转向的视觉问题
            player.HandleFlip(player.moveInput.x);
            stateMachine.ChangeState(player.moveState);
        }
    }
}
