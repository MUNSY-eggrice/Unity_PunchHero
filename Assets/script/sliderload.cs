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
        // operation.isDone; �۾��Ϸ� ������ boolean������ ��ȯ
        //operation.progress; �۾��� 0 �۾��Ϸ� 1 ��ȯ
        // operation.allowSceneActivation; true�϶� �� �ѱ�� false�� �� progress�� 0.9f���� ����, �ٽ� true�� �ؾ� �Ѿ �� �ִ�.
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
