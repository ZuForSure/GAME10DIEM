using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFollowPlayer : FollowPlayer
{
    [Header("Enemy Follow Player")]
    [SerializeField] protected EnemyController enemyController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
    }

    protected void FixedUpdate()
    {
        base.Update();
        this.Following();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyController != null) return;
        this.enemyController = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected override void Following()
    {
        if (GameController.Instance.isGameOver) return;

        if (!this.enemyController.EnemyDetectCollision.isPlayerComeIn) return;
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, this.player.position, this.speed * Time.fixedDeltaTime);
    }
}