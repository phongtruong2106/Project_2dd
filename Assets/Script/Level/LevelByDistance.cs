using System;
using UnityEngine;

public class LevelByDistance : Level
{
    [Header("By Distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected float distancePerLevel = 10f;

    protected virtual void FixedUpdate() {
        this.leveling();
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    protected virtual void leveling()
    {
        if(this.target == null) return;
        this.distance = Vector3.Distance(transform.position, target.position);
        int newLevel = this.GetLevelByDis();
        this.LevelSet(newLevel);
    }

    protected virtual int GetLevelByDis()
    {
        return Mathf.FloorToInt(this.distance/ this.distancePerLevel) + 1;
    }
}