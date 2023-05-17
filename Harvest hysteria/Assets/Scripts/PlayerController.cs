using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public LayerMask enemyMask;
    private bool inFight;
    private ContactFilter2D contactFilter;
    private List<Collider2D> enemies;
    private int enemyIndex;

    void Start()
    {
        movePoint.parent = null;
        contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(enemyMask);
        enemies = new List<Collider2D>();
    }

    void Update()
    {
        if (!inFight)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, movePoint.position) <= .01f)
            {
                Physics2D.OverlapCircle(transform.position, 1f, contactFilter, enemies);
                if (enemies.Count > 0) inFight = true;
                if (enemies != null)
                {
                    foreach (var collider in enemies)
                    {
                        collider.gameObject.GetComponent<EnemyController>().SetSliderVisible();
                    }
                }
            }

            if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
            {

                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    }
                }
                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var attackSucceed = enemies[enemyIndex].gameObject.GetComponent<EnemyController>().Attack();
                if (attackSucceed)
                {
                    enemyIndex += 1;
                    if (enemyIndex == enemies.Count)
                    {
                        enemyIndex = 0;
                        enemies = new List<Collider2D>();
                        inFight = false;
                    }
                }
                else
                {
                    Debug.Log("- health");
                }

            }
        }


    }
}
