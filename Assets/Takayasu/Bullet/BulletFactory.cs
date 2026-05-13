using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [SerializeField] TextDatas textDatas;
    [SerializeField] private Bullet bullet;
    private Canvas c;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        c = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(Vector2 pos, float x)
    {
        int rand = Random.Range(0, textDatas.text.Count - 1);

        GameObject parent = c.gameObject;
        var b = Instantiate(bullet, c.transform);
        b.SetParam(pos, x, textDatas.text[rand]);
    }
}
