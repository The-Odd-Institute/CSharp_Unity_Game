using UnityEngine;
using System.Collections;

public class TrailOpacity : MonoBehaviour
{
    void Awake ()
    {
        StartCoroutine("DropAlpha");
    }

    IEnumerator DropAlpha ()
    {
        for (float f = 0; f <= 1; f += Time.deltaTime)
        {
            Color current = GetComponent<Renderer> ().material.color;
            current.a = Mathf.Lerp (1.0f, 0.0f, f / 1);
            GetComponent<Renderer> ().material.color = current;
               
            yield return null;
        }
    }
}