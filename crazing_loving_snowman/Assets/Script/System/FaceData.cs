
using UnityEngine;

[CreateAssetMenu(fileName = "FaceData", menuName = "Data/FaceData")]
public class FaceData : ScriptableObject
{
    [SerializeField] private int stageNum;
    [SerializeField] private int faceType; // 0 1 2 ´« ÄÚ ÀÔ
    [SerializeField] private Sprite faceImage;
    [SerializeField] private Sprite scoreImage; // ±âº»
    

    public int StageNum { get => stageNum; }
    public Sprite FaceImage { get => faceImage; }
    public Sprite ScoreImage { get => scoreImage; }
   
    public int FaceType { get => faceType; }

}
