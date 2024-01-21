using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    [SerializeField] private FaceData faceData;
    public FaceData FaceData { get => faceData; }



    public Face(FaceData faceData)
    {

        this.faceData = faceData;


    }
}
