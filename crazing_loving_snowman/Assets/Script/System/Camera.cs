using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform target;//따라다닐 player지정  
    void Update()
    {
        gameObject.transform.position = new Vector3(target.position.x, target.position.y, gameObject.transform.position.z);
        //카메라가 player를 따라다니게 한다.  
        //카메라의 z위치는 비추려는 대상보다 뒤에있어야 하니까 자체적으로 z값을 준다.
        //메인카메라와 배경 오브젝트에 넣는다
    }
}
