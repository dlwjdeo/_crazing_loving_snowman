using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;//����ٴ� player����  
    void Update()
    {
        gameObject.transform.position = new Vector3(player.position.x, player.position.y, this.transform.position.z);
        //ī�޶� player�� ����ٴϰ� �Ѵ�.  
        //ī�޶��� z��ġ�� ���߷��� ��󺸴� �ڿ��־�� �ϴϱ� ��ü������ z���� �ش�.
        //����ī�޶�� ��� ������Ʈ�� �ִ´�
    }
}
