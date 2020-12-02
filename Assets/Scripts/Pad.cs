using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    GameManager gameManager;
    Rigidbody2D rb;

    public float maxX;

    float yPosition;
    float moveSpeed;

    bool isMouseActive;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        moveSpeed = 13f;
        yPosition = transform.position.y;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 padNewPosition;
        if (!gameManager.isPauseActive && !isMouseActive)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
        }

        if (gameManager.isPauseActive)
        {
            return;
        }
        else
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // находим координаты мыши в игровом экране координат
            padNewPosition = new Vector3(mouseWorldPosition.x, yPosition, 0); //Запоминаем двиежение платформы только  по X влево вправо и всё
            padNewPosition.x = Mathf.Clamp(padNewPosition.x, -maxX, maxX); //Не выходит за рамки игрового мира
            transform.position = padNewPosition; //Занесли координаты мыши в платфору двигаем её за мышкой
        }

    }
}
