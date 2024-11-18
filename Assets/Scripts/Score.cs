
using UnityEngine;

public class Score : MonoBehaviour
{
    private Player ScoreAdd;

    private int addSccore;
    // Update is called once per frame
    void Start()
    {
        ScoreAdd = GameObject.Find("Player").GetComponent<Player>();

        if(tag == "50 Score")
        {
            addSccore = 50;
        }
        else if(tag == "25 Score")
        {
            addSccore = 25;
        }
        else
        {
            addSccore = 10;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            ScoreAdd.AddCore(addSccore);
            Destroy(gameObject);
        }
    }
}
