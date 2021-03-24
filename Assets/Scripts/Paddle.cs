using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1.25f;
    [SerializeField] float maxX = 14.75f;

    GameStatus theGameSession;
    Ball theBall;

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else 
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);

        transform.position = paddlePos;
    }


}
