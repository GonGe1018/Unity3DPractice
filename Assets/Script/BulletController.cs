using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    RaycastHit hit;

    EnemyController enemyController;

    public new Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * 0.1f);
        StartCoroutine(bulletDestroy());
        rigidbody.velocity=transform.forward * 30f;//생성되는 즉시 이동 시작
        bulletCollision();

    }
    
    void bulletCollision()//총알 충돌 감지
    {
        if(Physics.Raycast(transform.position,transform.forward,out hit, 0.5f))
        {
            if(hit.collider.CompareTag("Enemy"))
            {
                enemyController=hit.collider.GetComponent<EnemyController>();
                enemyController.bulletHit();
            }
            print("총알 충돌");
            Destroy(gameObject);
            
        }
    }

    IEnumerator bulletDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
