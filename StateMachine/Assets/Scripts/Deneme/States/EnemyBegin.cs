using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class EnemyBegin : State
{
    #region Construction
    public EnemyBegin(EnemySystem enemySystem) : base(enemySystem)
    {
        EnemySystem.StartCoroutine(Start());
        Debug.Log("Begin");
    }
    #endregion

    #region Execution Override
    public override IEnumerator Start()
    {
        bool Attackable = CheckAttackPlayer(PositionManager.manager.Player);
        if (Attackable)
            EnemySystem.SetState(new EnemyAttack(EnemySystem));
        else
            EnemySystem.SetState(new EnemyPatrol(EnemySystem));
        yield break;
    }
    #endregion

    #region State Changers
    public bool CheckAttackPlayer(GameObject player)
    {
        if (Vector3.Distance(EnemySystem.transform.position, player.transform.position) <= EnemySystem.AttackRadius)
            return true;
        else
            return false;
    }
    #endregion
}
