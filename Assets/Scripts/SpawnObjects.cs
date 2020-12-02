using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    //Создаем массив обьектов которые будут выпадать
    public Rigidbody2D[] goodObject;
    public Rigidbody2D[] badObject;
    public Rigidbody2D[] specialObject;

    public float startTime;

    public float stepGood;
    public float stepBad;
    public float stepSpecial;

    public float speedModificator = 1.25f;
    public float stepSpeed = 5f;
    float speedKoef;

    private void Start()
    {
        speedKoef = 1;
        InvokeRepeating(nameof(IncreaseSpeed), startTime, stepSpeed);


        InvokeRepeating(nameof(GoodO), startTime, stepGood);
        InvokeRepeating(nameof(BadO), startTime, stepBad);
        InvokeRepeating(nameof(SpecialO), startTime, stepSpecial);
    }

    void IncreaseSpeed()
    {
        speedKoef *= speedModificator;
    }

    void GoodO()
    {
        StepSpawnObjects(goodObject);
    }
    void BadO()
    {
        StepSpawnObjects(badObject);
    }

    void SpecialO()
    {
        StepSpawnObjects(specialObject);

    }

    void StepSpawnObjects(Rigidbody2D[] objects)
    {
        int randomIndex = Random.Range(0, objects.Length);
        Vector2 dropPosition = new Vector2(Random.Range(-8f, 8f), 6f);
        Instantiate(objects[randomIndex], dropPosition, Quaternion.identity);
    }

}
