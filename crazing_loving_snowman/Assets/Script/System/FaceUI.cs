using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FaceUI : MonoBehaviour
{
    [SerializeField] private FaceScoreData faceScoreData;
    public FaceScoreData FaceScoreData { get => faceScoreData; }

    [SerializeField] private GameObject go_SlotsParent;  // Slot���� �θ��� Grid Setting 

    public FaceSlot[] slots;  // ���Ե� �迭

    [SerializeField] private List<Sprite> images = new List<Sprite>();
    void Start()
    {
        
        slots = go_SlotsParent.GetComponentsInChildren<FaceSlot>();

        //������ �� �̹��� ������� ����
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].GetComponent<Image>().sprite = images[i];
        }

        int startIndex = (SceneManager.GetActiveScene().buildIndex - 3) * 3;

        if (startIndex >= 0 && startIndex < FaceScoreData.Faces.Count) 
        {
            
            FaceScoreData.Faces.RemoveRange(startIndex, 3);
           
        }
        if (FaceScoreData.Faces.Count > 12)
        {
            FaceScoreData.Faces.RemoveRange(12, FaceScoreData.Faces.Count-12);
        }
    }

    public void AcquireItem(Face _faces,float _alpha)
    {
        //�̹��� �ٲٱ�
        slots[_faces.FaceData.FaceType].GetComponent<Image>().sprite = _faces.FaceData.FaceImage;

        Color color = slots[_faces.FaceData.FaceType].GetComponent<Image>().color;
        color.a = _alpha;
        slots[_faces.FaceData.FaceType].GetComponent<Image>().color = color;

    }

  
}
