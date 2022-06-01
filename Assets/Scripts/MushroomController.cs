using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    private Rigidbody2D mushroomBody;
    private int xDirection;
    private SpriteRenderer mushroomSprite;
    private float speed = 3.0f;
    private int[] possiblexDirections = {1,-1};


    // Start is called before the first frame update
    void Start()
    {
        mushroomBody = GetComponent<Rigidbody2D>();
        mushroomBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        xDirection = possiblexDirections[Random.Range(1,possiblexDirections.Length)];
        mushroomBody.AddForce(Vector2.up*18, ForceMode2D.Impulse);

        mushroomBody.AddForce(new Vector2(xDirection, 0)*speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate() {
        mushroomBody.velocity = new Vector2(xDirection*speed, mushroomBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") )
        {
            mushroomBody.velocity = Vector2.zero;
            xDirection = 0;
        }
        else if (col.gameObject.CompareTag("Obstacles")) {
            xDirection *= -1;
        }
        
    }

    void OnBecameInvisible() {
        Destroy(this.gameObject);
    }

}
