using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private void Start()
    {
        CreatePipe(0f, 0f);
        CreatePipe(0f, 20f);
    }
    private void CreatePipe(float height, float x)
    {
        Transform pipeHead = Instantiate(GameAssets.GetInstance().pipeHead);
        pipeHead.position = new Vector3(x, 0f);

        Transform pipeBody = Instantiate(GameAssets.GetInstance().pipeBody);
        pipeBody.position = new Vector3(x, 0f);
    }
}
