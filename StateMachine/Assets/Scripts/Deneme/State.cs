using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected EnemySystem EnemySystem;
    protected Coroutine C_Start, C_Update, C_Attacking, C_Patroling;
    public State(EnemySystem enemySystem)
    {
        EnemySystem = enemySystem;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }
    public virtual IEnumerator Update()
    {
        yield break;
    }

    public virtual IEnumerator Attacking()
    {
        yield break;
    }

    public virtual IEnumerator Patroling()
    {
        yield break;
    }
}
