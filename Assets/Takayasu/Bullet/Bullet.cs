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

    public void SetParam(Vector2 pos, float x, string text)
    {
        m_text = transform.GetComponent<TextMeshProUGUI>();

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(pos);
        GetComponent<RectTransform>().position = screenPoint;
        vec = x;
        m_text.text = text;

        // 子要素のテキストも更新（縁取り用など）
        if (transform.childCount > 0)
        {
            m_text.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}



