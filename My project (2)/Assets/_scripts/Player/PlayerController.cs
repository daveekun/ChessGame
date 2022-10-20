using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2Int PlayerCords;
    private float lastMoved;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 1 && lastMoved + moveSpeed < Time.time)
            Move("Right");
        else if (Input.GetAxisRaw("Horizontal") == -1 && lastMoved + moveSpeed < Time.time)
            Move("Left");
        if (Input.GetAxisRaw("Vertical") == 1 && lastMoved + moveSpeed < Time.time)
            Move("Up");
        else if (Input.GetAxisRaw("Vertical") == -1 && lastMoved + moveSpeed < Time.time)
            Move("Down");

    }
    void Move(string Direction)
    {
        lastMoved = Time.time;
        switch (Direction)
        {
            case "Up":
                PlayerCords.y += 1;
                transform.position = new Vector3(transform.position.x + 1, transform.position.y + 0.5f, 0);
                break;
            case "Down":
                PlayerCords.y -= 1;
                transform.position = new Vector3(transform.position.x - 1, transform.position.y - 0.5f, 0);
                break;
            case "Left":
                PlayerCords.x -= 1;
                transform.position = new Vector3(transform.position.x - 1, transform.position.y + 0.5f, 0);
                break;
            case "Right":
                PlayerCords.x += 1;
                transform.position = new Vector3(transform.position.x + 1, transform.position.y - 0.5f, 0);
                break;
        }
    }
}
