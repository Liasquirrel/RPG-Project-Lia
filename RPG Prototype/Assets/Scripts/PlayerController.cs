using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 20.0f;
    Rigidbody2D rigidbody2d;
    public Unit[] team = new Unit[5];

    bool mvHoz;
    bool mvVer;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        team[0] = new Unit(1, "Lia", 10, 14, 12, 8, 12, 16, "Human", "Fighter", true);
        UI.instance.stats(team[0]);

    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = 0;
        float vertical = 0;

        if (Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") != 0)
        {
            if (mvHoz)
            {
                vertical = Input.GetAxis("Vertical");
            }
            else if (mvVer)
            {
                horizontal = Input.GetAxis("Horizontal");
            }
        } else
        {
            mvHoz = Input.GetAxis("Horizontal") != 0;
            horizontal = Input.GetAxis("Horizontal");
            mvVer = Input.GetAxis("Vertical") != 0;
            vertical = Input.GetAxis("Vertical");
        }
        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

       // animator.SetFloat("Look X", lookDirection.x);
       // animator.SetFloat("Look Y", lookDirection.y);
       // animator.SetFloat("Speed", move.magnitude);

        Vector2 position = rigidbody2d.position;

        position = position + move * speed * Time.smoothDeltaTime;

        rigidbody2d.MovePosition(position);

    }
}
