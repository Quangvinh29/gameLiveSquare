using System.Collections;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    [SerializeField]
    private float Speed = 4f, LiveTime = 10f;

    private Transform targetPosition;

    private Vector2 direction;

    private bool Move = false;

    void Start()
    {
        targetPosition = GameObject.Find("Player").transform;
       StartCoroutine(SetDirection());
    }

    IEnumerator SetDirection()
    {
        yield return new WaitForSeconds(3f);
        Move = true;
    }

     void Update()
    {
        if(Move == true) 
        {
            direction = (targetPosition.position - transform.position).normalized;
            transform.Translate(direction * Speed * Time.deltaTime);
        }

        LiveTime -= Time.deltaTime;

        if (LiveTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
