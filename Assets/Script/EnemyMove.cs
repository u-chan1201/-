using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float Speed = 1f;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ヒエラルキーの中から GameManager を探して見つける
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);

        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. 弾（Bullet）に当たった場合
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // GameManagerの AddScore を呼んで10点（好きな数字）加算！
            gameManager.AddScore(10);

            // 弾を消す
            Destroy(collision.gameObject);

            // 自分（敵）を消す
            Destroy(this.gameObject);
        }
    }
}
