using UnityEngine;

public class LookAtPlayer : LookAtTarget
{
    [Header("Look At Player")]
    [SerializeField] protected Transform player;
    private void LateUpdate()
    {
        this.AimTarget(this.player.position);
    }

    protected override void LoadComponent()
    {
        this.LoadPlayer();
    }

    protected override void Start()
    {
        base.Start();
        this.LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player").transform;
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
    }

    
}
