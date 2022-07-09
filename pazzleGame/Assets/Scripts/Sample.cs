using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //animator.SetBool("TestBool", true); // "Float"‚É‚Íƒpƒ‰ƒ[ƒ^–¼‚ª“ü‚è‚Ü‚·
            animator.SetTrigger("TestTrigger");
        }
    }
}
