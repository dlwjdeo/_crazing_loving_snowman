
using UnityEngine;

[CreateAssetMenu(fileName = "FaceData", menuName = "Data/FaceData")]
public class FaceData : ScriptableObject
{
    [SerializeField] private int stageNum;
    [SerializeField] private int faceType;
    [SerializeField] private Sprite faceImage;
    [SerializeField] private Sprite scoreImage;

    public int StageNum { get => stageNum; }
    public Sprite FaceImage { get => faceImage; }
    public Sprite ScoreImage { get => scoreImage; }
    public int FaceType { get => faceType; }

}
