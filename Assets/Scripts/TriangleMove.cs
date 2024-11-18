using System.Collections;
using UnityEngine;

public class TriangleMove : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 direction, rotated;
    private Transform targetPosition; 

    private void Start()
    {
        targetPosition = GameObject.Find("Player").transform;
        StartCoroutine(SetDirection()); 
    }

     IEnumerator SetDirection()
     {
        yield return new WaitForSeconds(3f);

        if (targetPosition.position.x > transform.position.x && targetPosition.position.y > transform.position.y)
        {
            direction = new Vector2(1, 1); 
        }
        else if (targetPosition.position.x < transform.position.x && targetPosition.position.y > transform.position.y)
        {
            direction = new Vector2(-1, 1); 
        }
        else if (targetPosition.position.x > transform.position.x && targetPosition.position.y < transform.position.y)
        {
            direction = new Vector2(1, -1); 
        }
        else
        {
            direction = new Vector2(-1, -1); 
        }

        direction.Normalize();

        rotated =  new Vector3(0, 0, 1);
     }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        transform.Rotate(rotated);
    }
}
