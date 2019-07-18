using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
     public float speed = 1.0f;
     public float x1;
     public float y1;
     public float x2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos1 = new Vector2(x1, y1);

        Vector2 pos2 = new Vector2(x2, y1);

        transform.position = Vector2.Lerp (pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}
