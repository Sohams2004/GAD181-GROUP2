using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_Health : MonoBehaviour
{
    public float playerHealth = 1;
    public float damage = 0.2f;
    public float mathf;

    public bool decreaseHealth;
    public bool increaseHealth;

    public UnityEngine.UI.Image image;

    public Gradient gradient;

    private void Start()
    {
        decreaseHealth = false;
        increaseHealth = false;
    }
    public void HealthDecrease()
    {
        playerHealth -= damage * Mathf.Abs(mathf) * Time.deltaTime;

    }
    public void HealthIncrease()
    {
        playerHealth += playerHealth * Mathf.Abs(mathf) * Time.deltaTime;
    }

    private void Update()
    {
        if (decreaseHealth == true)
        {
            HealthDecrease();
        }
        else if(increaseHealth == true)
        {
            HealthIncrease();
        }
        else
        {
            image.fillAmount = playerHealth;
            image.color = gradient.Evaluate(image.fillAmount);
            decreaseHealth = false;
            increaseHealth = false;
        }
        /*image.fillAmount = playerHealth;
        image.color = gradient.Evaluate(image.fillAmount);

        image.fillAmount = playerHealth;
        image.color = gradient.Evaluate(image.fillAmount);*/
    }
}
