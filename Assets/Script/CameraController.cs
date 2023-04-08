using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;
    new Camera camera;
    Vector3 targetPos;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        skillMode();
        transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y+70,Player.transform.position.z-40);// 카메라 이동
    }

    void skillMode()//스킬 모드
    {
        if (Input.GetMouseButton(1))
        {
            // 마우스로 찍은 위치의 좌표 값을 가져온다
            ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000f))
            {
                if(hit.collider.tag=="tile")
                {
                    targetPos = hit.point;
                    Player.transform.LookAt(targetPos);
                }  
            }
            
        }
    }
}
