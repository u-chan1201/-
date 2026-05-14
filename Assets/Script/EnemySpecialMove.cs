using UnityEngine;

public class EnemySpecialMove : MonoBehaviour
{
    public float Speed = 2.0f;
    public float verticalSpeed = 3.0f;
    public float yRange = 3.0f;

    private int directionY = 1;

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
        //X軸への移動
        float moveX = -Speed * Time.deltaTime;

        //Y軸への移動
        float moveY = directionY * verticalSpeed * Time.deltaTime;

        //移動処理
        transform.Translate(new Vector3(moveX, moveY, 0));

        //上にぶつかったら跳ね返る
        if(transform.position.y >= yRange)
        {
            directionY = -1;
        }
        else if (transform.position.y <= -yRange)
        {
            directionY = 1;
        }

        //画面外に言ったら
        if (transform.position.x <= -12f)
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
