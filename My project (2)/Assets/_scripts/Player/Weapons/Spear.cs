using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public PlayerController player;
    EnemyManager em = EnemyManager.instance;
    public int damage;
    public void BasicAttack(string Direction)
    {
        /*
         left #  up
         # player #
         down # right
         */
        Vector2Int AttackPos = new Vector2Int(0,0);
        switch (Direction)
        {
            case "Up":
                AttackPos = player.PlayerCords + new Vector2Int(0, 1);
                break;
            case "Down":
                AttackPos = player.PlayerCords + new Vector2Int(0, -1);
                break;
            case "Left":
                AttackPos = player.PlayerCords + new Vector2Int(-1, 0);
                break;
            case "Right":
                AttackPos = player.PlayerCords + new Vector2Int(1, 0);
                break;
        }
        if (em.enemyPos[AttackPos] != null)
        {
            em.enemyPos[AttackPos].GetComponent<Health>().TakeDamage(damage);
        }
    }
}
