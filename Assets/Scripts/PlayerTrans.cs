using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// RequireComponent（コンポーネント型）と記述することによって
// 指定したコンポーネントを一緒に付けてくれるようになる
[RequireComponent(typeof(Rigidbody2D))]


public class PlayerTrans : MonoBehaviour
{

    Rigidbody2D rigidbody = null;
    public float movePower = 50.0f;
    public float jumpPower = 1.0f;
    public float maxSpeed = 3.0f;


    public void Restart()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(-8.75f, -4.01f, 0.0f);
    }

    public void GameOver()
    {
        gameObject.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        int key = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddForce(Vector2.right* movePower);
            key = 1;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddForce(Vector2.left * movePower);
            key = -1;
        }
        if (Input.GetKeyDown(KeyCode.Space))    // キーが押された瞬間のみ
        {
            // 瞬間的に大きな力を与える
            rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        // 速度制限
        if(Mathf.Abs(rigidbody.velocity.x) > maxSpeed)
        {
            var velocity = rigidbody.velocity;
            velocity.x = maxSpeed * key;
            rigidbody.velocity = velocity;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        Debug.Log(tag);

        if(tag == "Damage")
        {
            GameManager.Instance.GameOver();
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy(gameObject);
    }
}
