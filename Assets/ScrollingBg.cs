using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScrollingBg : MonoBehaviour
{
    public float scrollSpeed = 1f;
    private Vector2 startPosition;
    private float backgroundWidth;

    // Start is called before the first frame update
    void Start()
    {
        //startPosition = transform.position;
        backgroundWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(scrollSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x <= startPosition.x - backgroundWidth)
        {
            transform.position += new Vector3(backgroundWidth * 2, 0, 0);
        }

    }
}
