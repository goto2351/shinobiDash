using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerAttackColliderController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // “G‚ÉUŒ‚‚ª“–‚½‚Á‚½‚ÌÁ–Åˆ—
    public  void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
