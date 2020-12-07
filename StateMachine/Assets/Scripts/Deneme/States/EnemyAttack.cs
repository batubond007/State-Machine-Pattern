using System.Collections;
using System.Collections.Generic;
using UnityEngine;
internal class EnemyAttack : State
{
    #region Construction
    public EnemyAttack(EnemySystem enemySystem) : base(enemySystem)
    {
        EnemySystem.StartCoroutine(Start());
        Debug.Log("Attacking");
    }
    #endregion

    #region Execution Override
    public override IEnumerator Start()
    {
        C_Attacking = EnemySystem.StartCoroutine(Attacking());
        C_Update = EnemySystem.StartCoroutine(Update());
        yield break;
    }

    public override IEnumerator Update()
    {
        while (true)
        {

            if (CheckReturnFromAttack(PositionManager.manager.Player))
            {
                EnemySystem.StopCoroutine(C_Attacking);
                EnemySystem.SetState(new EnemyPatrol(EnemySystem));
                yield break;
            }

            yield return new WaitForEndOfFrame();
        }
    }

    public override IEnumerator Attacking()
    {
        while (true)
        {
            EnemySystem.transform.position = Vector3.MoveTowards(EnemySystem.transform.position, PositionManager.manager.Player.transform.position, 5 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    #endregion

    #region State Changers
    public bool CheckReturnFromAttack(GameObject player)
    {
        if (Vector3.Distance(EnemySystem.transform.position, player.transform.position) > EnemySystem.AttackRadius + 5)
            return true;
        else
            return false;
    }
    #endregion
}