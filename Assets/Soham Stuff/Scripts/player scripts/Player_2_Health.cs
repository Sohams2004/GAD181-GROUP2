using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2_Health : MonoBehaviour
{
    public float playerHealth = 1;
    public float damage = 0.2f;
    public float mathf;

    public bool decreaseHealth;

    public UnityEngine.UI.Image image;

    public Gradient gradient;

    private void Start()
    {
        decreaseHealth = false;
    }
    public void HealthDecrease()
    {
        playerHealth -= damage * Mathf.Abs(mathf) * Time.deltaTime;
    }


    private void Update()
    {
        if (decreaseHealth == true)
        {
            HealthDecrease();
        }

        image.fillAmount = playerHealth;
        image.color = gradient.Evaluate(image.fillAmount);
    }
}
