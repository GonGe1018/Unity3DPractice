using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyrController : MonoBehaviour
{
    public Animator animator;

    public new Camera camera;
    
    float hAxis; float vAxis; bool wDown;

    float xRotate = 0.0f;
    public float speed = 15f;
    Vector3 moveVec;


    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");//A D
        vAxis = Input.GetAxisRaw("Vertical");//W S
        wDown = Input.GetButton("Walk");//Shift
    }

    void Move()
    {
        moveVec = new Vector3(hAxis,0,vAxis).normalized;//호리즌과 버티컬 값을 vector3로 변환, 그리고 normalized를 통하여 벡터 값을 항상 1로 고정

        transform.position += moveVec*speed*Time.deltaTime;

        animator.SetBool("isRun",moveVec != Vector3.zero);//움직일 경우 isRun을 True로 바꿈
        animator.SetBool("isWalk",wDown);

        if(Input.GetMouseButton(1)==false)//우클릭으로 플레이어를 회전 하고 있지 않을 때 WSAD에 따른 회전을 한다.
        {
            transform.LookAt(transform.position + moveVec);
        }
        
    }


}
