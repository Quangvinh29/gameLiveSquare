
using System.Collections;
using UnityEngine;

public class SquareMove : MonoBehaviour
{
    public float speed = 5f; 
    private Vector2 direction;
    private Transform TargetPosition;

    private void Start()
    {
        TargetPosition = GameObject.Find("Player").transform;
        StartCoroutine(SetDirection());
    }

    IEnumerator SetDirection()
    {
        yield return new WaitForSeconds(3f);

        if (TargetPosition.position.x > transform.position.x)
        {
            direction = Vector3.right; 
        }
        else if (TargetPosition.position.x < transform.position.x)
        {
            direction = Vector3.left; 
        }
        else if (TargetPosition.position.y > transform.position.y)
        {
            direction = Vector3.up; 
        }
        else
        {
            direction = Vector3.down; 
        }
    }

    void Update()
    {
        transform.Translate( direction * speed * Time.deltaTime);

    }
}
