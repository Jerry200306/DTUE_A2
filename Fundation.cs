using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fundation : MonoBehaviour
{

    private Transform angelTransform;
    public float moveStep = 2.0f;
    public float scaleFactor = 0.2f;
    public float rotateSpeed = 30f;

    private Vector3 initialPosition;
    private Vector3 initialScale;
    private Quaternion initialRotate;

    void Start()
    {
        GameObject angelObject = GameObject.Find("Angel");

        if (angelObject != null)
        {
            angelTransform = angelObject.transform;
            initialPosition = angelTransform.position;
            initialScale = angelTransform.localScale;
            initialRotate = angelTransform.rotation;
            Debug.Log("Angel Find! ");
        }
        else
        {
            Debug.LogError("Not Find£¡");
        }
    }

    public void MoveLeft()
    {
        angelTransform.Translate(-moveStep, 0, 0);
    }

    public void MoveRight()
    {
        angelTransform.Translate(moveStep, 0, 0);
    }

    public void ScaleUp()
    {
        angelTransform.localScale *= (1 + scaleFactor);
    }

    public void ScaleDown()
    {
        angelTransform.localScale *= (1 - scaleFactor);
    }

    public void ResetAll()
    {
        angelTransform.position = initialPosition;
        angelTransform.localScale = initialScale;
        angelTransform.rotation=initialRotate;
    }
    public void Rotate() 
    {
        angelTransform.Rotate(0, rotateSpeed, 0); 
    }
    public void GoToNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        int nextSceneIndex = (currentSceneIndex + 1) % sceneCount;
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void ExitScene()
    {
        SceneManager.LoadScene(0);
    }
    }
