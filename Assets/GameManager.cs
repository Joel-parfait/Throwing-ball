using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Ball_in;
    public int Ball_max;
    public Text Ball_inText;
    public Text Ball_maxText;
    public static GameManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il ya plus d'une instance dans la scène");
        }
        instance = this;    
    }
    public void AddBall(int Ball)
    {
        Ball_in += Ball;
        Ball_inText.text = Ball_in.ToString();
    }
    public void MoveBall(int Ball)
    {
        Ball_max -= Ball;
        Ball_maxText.text = Ball_max.ToString();
    }
}
