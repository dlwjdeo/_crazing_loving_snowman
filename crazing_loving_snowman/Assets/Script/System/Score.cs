using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    [SerializeField] private FaceScoreData faceScoreData;
    public FaceScoreData FaceScoreData { get => faceScoreData; }

    [SerializeField]
    private List<GameObject> slot;
    // Start is called before the first frame update
    void Start()
    {
        if (FaceScoreData != null)
        {
            for (int i = 0; i < FaceScoreData.Faces.Count; i++)
            {
                if (FaceScoreData.Faces[i].FaceType != 5)
                {
                    slot[i].GetComponent<Image>().sprite = FaceScoreData.Faces[i].ScoreImage;
                }
            }
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
