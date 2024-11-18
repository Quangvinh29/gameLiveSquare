using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed = 15f, dashSpeed = 25f;
    public float dashTime = 0.1f, InDash;
    public float DashRecover;

    public GameObject[] Health;
    public int MaxHealth = 4;

    public int  currentDash = 0;
    private bool isDashing = false;

    private UIManager UI;
    private SpawnS SpawnScore;
    private SpawnEnemy SpawnE;

    private int TotalScore;

    private float UnDamageTime = 2.5f, UnDamage;
    private bool Damaged = false;

    [SerializeField]
    private int ScoreUpdate = 200;

    private void Start()
    {
        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
        SpawnScore = GameObject.Find("SpawnScore").GetComponent<SpawnS>();
        SpawnE = GameObject.Find("SpawnEnemy").GetComponent<SpawnEnemy>();

    }
    void Update()
    {
        UI.ScoreUpdate(TotalScore);
        UI.DashUpdate(currentDash);

        if (DashRecover > 0)
        {
            DashRecover -= Time.deltaTime; // Giảm thời gian hồi 
            if (DashRecover < 0) DashRecover = 0; // Đảm bảo không có giá trị âm
            if (DashRecover == 0) currentDash = 0;
        }

        if(Damaged == true)
        {
            UnDamage -= Time.deltaTime;
            if (UnDamage < 0) UnDamage = 0;
            if (UnDamage == 0) Damaged = false;
        }

        if (isDashing == false && Input.GetKeyDown(KeyCode.Space))
        {
            DashCount();
        }

        if( TotalScore >= ScoreUpdate)
        {
            InscreateSpawn();
        }

        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(Horizontal, Vertical);
        transform.Translate(movement * speed * Time.deltaTime);

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -10.7f, 10.7f), Mathf.Clamp(transform.position.y, -4.8f, 4.8f));
    }

    private void DashCount()
    {
         if (currentDash >= 0 && currentDash < 3 && TotalScore >= 20)
         {
             TotalScore -= 20;
            StartCoroutine(Dash());
        }
         else if ( currentDash >= 3 && currentDash < 6 && TotalScore >= 40) 
         {
            TotalScore -= 40;
            StartCoroutine(Dash());
        }
         else if (currentDash >= 6 && TotalScore >= 60)
         {
            TotalScore -= 60;
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        currentDash++;
        InDash = dashTime;
        isDashing = true;
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector2 DashMove = new Vector2(Horizontal, Vertical).normalized;

        while (InDash > 0)
        {
            transform.Translate(DashMove * dashSpeed * Time.deltaTime);
            InDash -= Time.deltaTime;
            yield return null;
        }
        DashRecover = 3f;
        isDashing = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(Damaged == false)
        {
            if(isDashing == false)
            {
                if (other.tag == "Square")
                {
                    Damage();
                    Destroy(other.gameObject);
                }
                else if (other.tag == "Triangle")
                {
                    Damage();
                    Destroy(other.gameObject);
                }
                else if (other.tag == "Circle")
                {
                    Damage();
                    Destroy(other.gameObject);
                }
                
            }
        } 
    }

    private void Damage()
    {
        Damaged = true;
        Health[(MaxHealth-1)].SetActive(true);
        MaxHealth--;
        UnDamage = UnDamageTime;

        if (MaxHealth == 0)
        {
            UI.GameOverUI(TotalScore);
            Time.timeScale = 0;
        }
    }

    public void AddCore(int Score)
    {
        TotalScore += Score;
    }

    private void InscreateSpawn()
    {
        ScoreUpdate += 150;
        SpawnScore.DecreaseSpawnSTime();
        SpawnE.DecreaseSpawnEnemyTime();
    }
    
}