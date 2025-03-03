using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBg : MonoBehaviour
{
    public float scrollSpeed = 1f;
    private Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosX = Mathf.Repeat(Time.time * scrollSpeed, 20); // Adjust 20 to the background's width
        transform.position = startPosition + Vector2.left * newPosX;

    }
}
