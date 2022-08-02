using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtackController : MonoBehaviour
{
    [SerializeField] private GameObject collider_sword; // �ߐڍU���̓����蔻��p�I�u�W�F�N�g
    private float timer;
    private bool isAttacking;
    private GameObject attackCollider;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {
            timer += Time.deltaTime;
            if (timer >= 0.5f)
            {
                DestroyAtackCollider();
            }
        }
    }

   public void MakeAtackCollider()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            Vector3 pos = gameObject.transform.position;
            pos += new Vector3(0.75f, 0, 0);
            attackCollider = (GameObject)Instantiate(collider_sword, pos, Quaternion.identity);
            attackCollider.transform.parent = gameObject.transform;
        }
    }

    void DestroyAtackCollider()
    {
        Destroy(attackCollider);
        isAttacking = false;
        timer = 0;
    }
    
}
