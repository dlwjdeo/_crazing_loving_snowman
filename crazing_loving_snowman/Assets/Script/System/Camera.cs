using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform target;//����ٴ� player����  
    void Update()
    {
        gameObject.transform.position = new Vector3(target.position.x, target.position.y, gameObject.transform.position.z);
        //ī�޶� player�� ����ٴϰ� �Ѵ�.  
        //ī�޶��� z��ġ�� ���߷��� ��󺸴� �ڿ��־�� �ϴϱ� ��ü������ z���� �ش�.
        //����ī�޶�� ��� ������Ʈ�� �ִ´�
    }
}
