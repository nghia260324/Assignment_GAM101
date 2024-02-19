using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithButtonUi : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D m_rigidbody2D;

    private float currentMoveSpeed;

    private bool isRight;
    private bool isLeft;
    private GameObject player;
    private void Start()
    {
        currentMoveSpeed = moveSpeed;
        isRight = false;
        isLeft = false;
    }

    public void moveRight() {  isRight = true; }
    public void moveLeft() {  isLeft = true; }

    public void PointerUpRight() { isRight = false; }
    public void PointerDownLeft() {  isLeft = false; }
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;
        m_rigidbody2D = player.GetComponent<Rigidbody2D>();
        Movement();
    }

    private void Movement()
    {
        if (isRight)
        {
            currentMoveSpeed = moveSpeed;
        } else if (isLeft)
        {
            currentMoveSpeed = -moveSpeed;
        } else
        {
            currentMoveSpeed = 0;
        }
        m_rigidbody2D.velocity = new Vector2(currentMoveSpeed, m_rigidbody2D.velocity.y);
    }
}
