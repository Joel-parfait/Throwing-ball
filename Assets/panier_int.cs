using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panier_int : MonoBehaviour
{
    public bool isPermeable = false;
    public GameObject BallSpawn;
    
    void Start() {
      //BallSpawn.SetActive(false);  
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("panier_int"))
        {
            GameManager.instance.AddBall(1);
            //Destroy(gameObject);
            //collision.transform.position = GameObject.FindGameObjectWithTag("BallSpawn").transform.position;
            LevelManager.instance.pushForce = 0f;
            BallSpawn.SetActive(true);
            GameObject.FindGameObjectWithTag("Ball").transform.position = GameObject.FindGameObjectWithTag("BallSpawn").transform.position;
            StartCoroutine(BallSpawnAppaerDelay());
        }
        if(collision.CompareTag("panier_ext"))
        {
            GameManager.instance.MoveBall(1);
            //Destroy(gameObject);
            LevelManager.instance.pushForce = 0f;
            BallSpawn.SetActive(true);
            GameObject.FindGameObjectWithTag("Ball").transform.position = GameObject.FindGameObjectWithTag("BallSpawn").transform.position;
            StartCoroutine(BallSpawnAppaerDelay());

        }
        if(collision.CompareTag("Outzone_en"))
        {
            if(!isPermeable)
            {
                GameManager.instance.MoveBall(1);
                isPermeable = true;
                StartCoroutine(PermeableDelay());
            }
        }
        if(collision.CompareTag("G_limit"))
        {
            GameManager.instance.MoveBall(1);
            //Destroy(gameObject);
            LevelManager.instance.pushForce = 0f;
            BallSpawn.SetActive(true);
            GameObject.FindGameObjectWithTag("Ball").transform.position = GameObject.FindGameObjectWithTag("BallSpawn").transform.position;
            StartCoroutine(BallSpawnAppaerDelay());

        }
        if(collision.CompareTag("D_limit"))
        {
            GameManager.instance.MoveBall(1);
            //Destroy(gameObject);
            LevelManager.instance.pushForce = 0f;
            BallSpawn.SetActive(true);
            GameObject.FindGameObjectWithTag("Ball").transform.position = GameObject.FindGameObjectWithTag("BallSpawn").transform.position;
            StartCoroutine(BallSpawnAppaerDelay());

        }
        if(collision.CompareTag("B_limit"))
        {
            GameManager.instance.MoveBall(1);
            //Destroy(gameObject);
            LevelManager.instance.pushForce = 0f;
            BallSpawn.SetActive(true);
            GameObject.FindGameObjectWithTag("Ball").transform.position = GameObject.FindGameObjectWithTag("BallSpawn").transform.position;
            StartCoroutine(BallSpawnAppaerDelay());

        }
        IEnumerator PermeableDelay()
        {
            while (isPermeable)
            {
                yield return new WaitForSeconds(4f);
                isPermeable = false;
            }
        }
        IEnumerator BallSpawnAppaerDelay()
        {
                yield return new WaitForSeconds(2f);
                BallSpawn.SetActive(false);
                LevelManager.instance.pushForce = 4f;
        }
    }
}
