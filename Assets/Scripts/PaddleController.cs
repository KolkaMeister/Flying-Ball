using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PaddleController : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    Ball theBall;
    GameSession theGameSession;
    void Start()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * 40);
        theBall = FindObjectOfType<Ball>();
        theGameSession = FindObjectOfType<GameSession>();
        GetMousePos();
    }

    void Update()
    {

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXpos(), minX, maxX);
        transform.position = paddlePos;
        transform.rotation = Quaternion.LookRotation(Vector3.forward * 20);
        //var betweenX = GetXpos() - transform.position.x;
        //var betweenY = GetYpos() - transform.position.y;
        //var angle = Mathf.Atan2(betweenY , betweenX) * Mathf.Rad2Deg;
        //transform.rotation= Quaternion.Euler(new Vector3(0, 0, angle-90));

    }
    private float GetXpos()
    {
        if (theGameSession.IsCheating())
        {
            return theBall.transform.position.x;
        }
        else
        {
           return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
    private float GetYpos()
    {
        if (theGameSession.IsCheating())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.y / Screen.width * screenWidthInUnits;
        }
    }
    private void GetMousePos()
    {
        Debug.Log(Mathf.Atan(Input.mousePosition.y/Input.mousePosition.x));
    }
}
