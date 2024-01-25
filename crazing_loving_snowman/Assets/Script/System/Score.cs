using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    [SerializeField] private FaceScoreData faceScoreData;
    public FaceScoreData FaceScoreData { get => faceScoreData; }

    [SerializeField]
    private GameObject Parent;

    [SerializeField] private Image[] scores;
    [SerializeField] private List<Sprite> images = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {

        scores = Parent.GetComponentsInChildren<Image>();

        for (int i = 0; i < scores.Length; i++)
        {
            images.Add(scores[i].GetComponent<Image>().sprite); //시작 이미지 다른 곳에 저장 해두기
        }
    }
  
    public void ScoreUpdate(int stageNum)
    {
        Debug.Log(stageNum);

        for (int i = 0; i < scores.Length; i++)
        {
            scores[i].GetComponent<Image>().sprite = images[i]; //기본 이미지로 초기화하고
        }
        if (FaceScoreData != null) // 데이터에 있는 스코어 띄우기
        {
            for (int i = 0; i < FaceScoreData.Faces.Count; i++)
            {
                if (FaceScoreData.Faces[i].StageNum == stageNum && FaceScoreData.Faces[i].FaceType != 5) //
                {
                    scores[FaceScoreData.Faces[i].FaceType].GetComponent<Image>().sprite = FaceScoreData.Faces[i].ScoreImage;
                }
               
            }
        }

        Parent.SetActive(true);
    }
}
