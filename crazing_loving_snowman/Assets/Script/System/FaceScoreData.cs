using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FaceScoreData", menuName = "Data/FaceScoreData")]

public class FaceScoreData : ScriptableObject
{
    [SerializeField] private List<FaceData> faces = new List<FaceData>();
    public List<FaceData> Faces { get => faces; }

    public void Add(FaceData newData)
    {
        for(int i = 0; i < 5; i++)
        {
            if (newData.StageNum == i+1)
                faces.Insert(i*3, newData);

        } 
    }
  
}
