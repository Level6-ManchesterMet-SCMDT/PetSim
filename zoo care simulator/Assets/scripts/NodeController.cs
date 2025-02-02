using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    //public bool canMoveLeft = false;
    //public bool canMoveRight = false;
    //public bool canMoveUp = false;
    //public bool canMoveDown = false;

    public GameObject nodeLeft;
    public GameObject nodeMiddleLeft;
    public GameObject nodeMiddleRight;
    public GameObject nodeRight;

    // if the node has a pellet when the game starts
    public bool isFruitNode = false;
    // if the node still has a pellet
    public bool hasFruit = false;

    public SpriteRenderer fruitSprite;

    private void Awake()
    {
        if (transform.childCount > 0)
        {
            hasFruit = true;
            isFruitNode = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isFruitNode)
        {
            hasFruit = false;
        }
    }
    //// Start is called before the first frame update
    //void Start()
    //{
    //    RaycastHit2D[] hitsDown;
    //    hitsDown = Physics2D.RaycastAll(transform.position, -Vector2.up);

    //    for (int i = 0; i < hitsDown.Length; i++)
    //    {
    //        float distance = Mathf.Abs(hitsDown[i].point.y - transform.position.y);
    //        if (distance < 0.4f)
    //        {
    //            canMoveDown = true;
    //            nodeDown = hitsDown[i].collider.gameObject;
    //        }
    //    }  

    //    RaycastHit2D[] hitsUp;
    //    hitsUp = Physics2D.RaycastAll(transform.position, Vector2.up);

    //    for (int i = 0; i < hitsUp.Length; i++)
    //    {
    //        float distance = Mathf.Abs(hitsUp[i].point.y - transform.position.y);
    //        if (distance < 0.4f)
    //        {
    //            canMoveUp = true;
    //            nodeUp = hitsUp[i].collider.gameObject;
    //        }
    //    }

    //    RaycastHit2D[] hitsLeft;
    //    hitsLeft = Physics2D.RaycastAll(transform.position, -Vector2.right);

    //    for (int i = 0; i < hitsLeft.Length; i++)
    //    {
    //        float distance = Mathf.Abs(hitsLeft[i].point.x - transform.position.x);
    //        if (distance < 0.4f)
    //        {
    //            canMoveLeft = true;
    //            nodeLeft = hitsLeft[i].collider.gameObject;
    //        }
    //    }

    //    RaycastHit2D[] hitsRight;
    //    hitsRight = Physics2D.RaycastAll(transform.position, Vector2.right);

    //    for (int i = 0; i < hitsRight.Length; i++)
    //    {
    //        float distance = Mathf.Abs(hitsRight[i].point.x - transform.position.x);
    //        if (distance < 0.4f)
    //        {
    //            canMoveRight = true;
    //            nodeRight = hitsRight[i].collider.gameObject;
    //        }
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
