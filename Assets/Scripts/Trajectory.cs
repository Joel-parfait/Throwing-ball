using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int dotsNumber;
    [SerializeField] GameObject DotsParent;
    [SerializeField] GameObject DotsPrefab;
    [SerializeField] float dotsSpacing;
    [SerializeField] [Range(0.01f, 0.5f)] float dotMinScale;
    [SerializeField] [Range(0.5f, 1f)] float dotMaxScale;
    Transform[] dotsList;
    Vector2 pos;
    float TimeStamp;
    private void Start()
    {
        Hide();
        PrepareDots();
    }
    void PrepareDots()
    {
        dotsList = new Transform[dotsNumber];
        DotsPrefab.transform.localScale = Vector3.one * dotMaxScale;
        float scale = dotMaxScale;
        float scaleFactor = scale /dotsNumber;
        for(int i = 0; i < dotsNumber; i++)
        {
            dotsList[i] = Instantiate(DotsPrefab, null).transform;
            dotsList[i].parent = DotsParent.transform;
            dotsList[i].localScale = Vector3.one * scale;
            if(scale > dotMinScale)
            {
                scale -= scaleFactor;
            }
        }
    }
    public void UpdateDots(Vector3 ballPos, Vector2 forceApplied)
    {
        TimeStamp = dotsSpacing;
        for(int i = 0; i < dotsNumber; i++)
        {
            pos.x = (ballPos.x + forceApplied.x * TimeStamp);
            pos.y = (ballPos.y + forceApplied.y * TimeStamp) - (Physics2D.gravity.magnitude*TimeStamp*TimeStamp) /2f;
            dotsList[i].position = pos;
            TimeStamp += dotsSpacing;
        }
    }
    public void Show()
    {
        DotsParent.SetActive(true);
    }
    public void Hide()
    {
        DotsParent.SetActive(false);
    }
}