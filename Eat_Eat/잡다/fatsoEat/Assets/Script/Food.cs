using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Food : MonoBehaviour {
    public GameObject hp_Bar;
    public GameObject hp_Bar_Dish;
    public GameObject timerBar;

    public float maxHP = 100.0f;
    public float currentHP = 100.0f;

    public float currentTimer = 15.0f;
    public float maxTimer = 15.0f;

    public Text timeText;

    float health=0.0f;
    float timeHealth=0.0f;

    PlayerControll playerControll;
    Food_Dish_Rotation food_Dish_Rotation;

    
    void Awake()
    {
        playerControll = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
        food_Dish_Rotation = GameObject.Find("Food_Dish_Rotation").GetComponent<Food_Dish_Rotation>();
    }

    void Update()
    {
        Timer();
    }
    public void Damage()
    {
        currentHP -= playerControll.power;
        Decreasehealth();
    }
    public void Decreasehealth()
    {
        health = currentHP / maxHP;
        SetHealthBar();

        if(currentHP<=0)
        {
            currentHP = 0f;
            FoodChange();
        }
    }
    public void SetHealthBar()
    {
        hp_Bar.transform.localScale = new Vector3(health, hp_Bar.transform.localScale.y, hp_Bar.transform.localScale.z);
        hp_Bar_Dish.transform.localScale = new Vector3(health, hp_Bar_Dish.transform.localScale.y, hp_Bar_Dish.transform.localScale.z);
    }

    public void Timer()
    {
        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
            timeText.text = currentTimer.ToString("N1");

            float timeHealth = currentTimer / maxTimer;

            timerBar.transform.localScale = new Vector3(timeHealth, timerBar.transform.localScale.y, timerBar.transform.localScale.z);
        }
        else
        {
            currentTimer = maxTimer;
            currentHP = maxHP;

            health = currentHP / maxHP;
            hp_Bar.transform.localScale = new Vector3(health, hp_Bar.transform.localScale.y, hp_Bar.transform.localScale.z);
            hp_Bar_Dish.transform.localScale = new Vector3(health, hp_Bar_Dish.transform.localScale.y, hp_Bar_Dish.transform.localScale.z);
            timerBar.transform.localScale = new Vector3(timeHealth, timerBar.transform.localScale.y, timerBar.transform.localScale.z);
        }
    }

    public void FoodChange()
    {
        food_Dish_Rotation.Food_Change();
    }
}
