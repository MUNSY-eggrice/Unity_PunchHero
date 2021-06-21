using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class sliderload : MonoBehaviour
{
    public Slider progressbar;
    private void Start()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync("INGAME");
        //  operation.allowSceneActivation = false;
        // operation.isDone; 작업완료 유무를 boolean형으로 봔환
        //operation.progress; 작업중 0 작업완료 1 반환
        // operation.allowSceneActivation; true일때 씬 넘기고 false일 때 progress를 0.9f에서 정지, 다시 true를 해야 넘어갈 수 있다.
        while (!operation.isDone)
        {
            yield return null;
            if(progressbar.value < 1f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }
        }

    }
}
