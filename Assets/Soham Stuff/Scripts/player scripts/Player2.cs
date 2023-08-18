using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public GameObject player;

    public bool toggleColor;

    public SpriteRenderer spriteRenderer;

    public IEnumerator ChangePlayerColor()
    {
        if (!toggleColor)
        {
            spriteRenderer.color = Color.white;
            yield break;
        }
        else
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(ChangePlayerColor());
        }
    } 
}
