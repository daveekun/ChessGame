using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Enemy : MonoBehaviour
{
    // health and stats
    public Health health;
    public int AttackDamage;
    public string type;
    // position and Movement
    public Vector2Int spawnCords;
    public Vector2Int currentCords;
    public List<string> movesToDo;

    public virtual void CalculateMovesToTarget(Vector2Int cords)
    {
        movesToDo = new List<string>();
    }

    public virtual void Move(string direction)
    {
        Debug.Log(movesToDo);
    }
}
