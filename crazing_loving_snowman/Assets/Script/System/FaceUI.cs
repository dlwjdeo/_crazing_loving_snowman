using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FaceUI : MonoBehaviour
{
    [SerializeField] private FaceScoreData faceScoreData;
    public FaceScoreData FaceScoreData { get => faceScoreData; }

    [SerializeField] private GameObject SlotsParent;  // Slot���� �θ��� Grid Setting 

    private FaceSlot[] slots;  // ���Ե� �迭


    [SerializeField] private GameObject ScoresParent;
    private Image[] scores;
    [SerializeField] private Sprite[] scoreImages;
    [SerializeField] private List<Sprite> images = new List<Sprite>();
    void Start()
    {
       
        slots = SlotsParent.GetComponentsInChildren<FaceSlot>(); 
        scores = ScoresParent.GetComponentsInChildren<Image>();

        //������ �� �̹��� ��������
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].GetComponent<Image>().sprite = images[i];
        }

        //�������� �����Ҷ� ������ �ʱ�ȭ

        DataReset();



    }
   public void DataReset()
    {
        int startIndex = (SceneManager.GetActiveScene().buildIndex - 3) * 3;

        if (startIndex >= 0 && FaceScoreData.Faces.Count > 2)
        {

            FaceScoreData.Faces.RemoveRange(startIndex, 3);

        }
        if (FaceScoreData.Faces.Count < 2)
        {
            FaceScoreData.Faces.Clear();
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
    public void ScoreChange(Face _faces)
    {
        if(_faces.FaceData.FaceType == 0)
        {
            scores[_faces.FaceData.FaceType].sprite = scoreImages[_faces.FaceData.FaceType];
        }
        scores[_faces.FaceData.FaceType+1].sprite = scoreImages[_faces.FaceData.FaceType];
    }



}
