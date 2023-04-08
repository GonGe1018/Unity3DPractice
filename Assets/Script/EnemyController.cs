using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hp = 10;
    new Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp<=0)
        {
            print("Enemy 사망");
            Destroy(gameObject);
        }
    }

    public void bulletHit()//총알에 맞았다면
    {
        hp--;
        StartCoroutine(hitColor());
        print($"적에 충돌; 현재 체력 {hp}");
    }

    IEnumerator hitColor()//충돌시 색깔 변경
    {
        renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        renderer.material.color = Color.white;
    }


}
