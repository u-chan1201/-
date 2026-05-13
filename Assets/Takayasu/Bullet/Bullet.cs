using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    float vec;

    private Rigidbody2D rb;
    private TextMeshProUGUI m_text;

    private Camera camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        this.rb.AddForce(new Vector2(vec, 0.0f));

        if(GetComponent<RectTransform>().position.x > 1000)
        {
            Destroy(this.gameObject);
        }
    }

    // パラメータ設定
    public void SetParam(Vector2 pos, float x, string text)
    {
        Debug.Log(m_text);

        m_text = transform.GetComponent<TextMeshProUGUI>();

        Vector3 screenPoint = camera.WorldToScreenPoint(pos);
        GetComponent<RectTransform>().position = screenPoint;
        vec = x;
        m_text.text = text;
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}



