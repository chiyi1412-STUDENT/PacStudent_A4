using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public Vector2Int grid;
    Vector2Int last;
    Vector2Int cur;
    Vector3 target;
    bool moving;

    bool Free(Vector2Int p) => true; // test

    void Start()
    {
        grid = Vector2Int.RoundToInt(transform.position);
        target = new Vector3(grid.x, grid.y, 0);
        cur = Vector2Int.right;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) last = Vector2Int.up;
        if (Input.GetKeyDown(KeyCode.S)) last = Vector2Int.down;
        if (Input.GetKeyDown(KeyCode.A)) last = Vector2Int.left;
        if (Input.GetKeyDown(KeyCode.D)) last = Vector2Int.right;

        if (!moving)
        {
            if (Go(last)) cur = last;
            else Go(cur);
        }

        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            if ((transform.position - target).sqrMagnitude < 0.0001f)
            {
                transform.position = target;
                moving = false;
            }
        }
    }

    bool Go(Vector2Int dir)
    {
        if (dir == Vector2Int.zero) return false;
        Vector2Int next = grid + dir;
        if (!Free(next)) return false;
        grid = next;
        target = new Vector3(grid.x, grid.y, 0);
        moving = true;
        return true;
    }
}
