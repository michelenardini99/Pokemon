using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    
    private bool isMoving;
    private Vector2 input;

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");

            if(input != Vector2.zero)   //player is moving
            {
                var targetPos = transform.position;     //transform.postion == current position of the player
                targetPos.x += input.x;
                targetPos.y += input.y; 

                StartCoroutine(Move(targetPos));
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {

        isMoving = true;

        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)    
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }
}
