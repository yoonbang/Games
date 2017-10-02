using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Loading : MonoBehaviour
{

    public Image Script;
    public Image ScriptPercent;
    public Text textScript;
    public GameObject LoadingBar;
    AsyncOperation async;
    bool IsDone = false;

    bool IsLoadGame = false;
    bool LoadingSuccess = false;

    public GameObject start;

    float fTime = 0f;

    void Start()
    {
        StartCoroutine("StartLoad", "InGame");
    }

    public IEnumerator StartLoad(string strSceneName)
    {
        async = Application.LoadLevelAsync(strSceneName);
        async.allowSceneActivation = false;


        if (IsLoadGame == false)
        {
            while (async.isDone == false)
            {
                float p = async.progress * 100f;
                int pRounded = Mathf.RoundToInt(p);

                textScript.text = pRounded.ToString();
                //progress 변수로 0.0f ~ 1.0f로 넘어 오기에 이용하면 됩니다.
                ScriptPercent.fillAmount = async.progress;

                if (async.progress == 0.9f)
                {
                    ScriptPercent.fillAmount = 1.0f;
                    pRounded = 100;
                    textScript.text = pRounded.ToString();
                    LoadingSuccess = true;
                }

                yield return true;
            }
        }
    }



    //로딩 페이지에서 연속으로 애니메이션 만들때 Update 함수 내에서 만들면 됩니다.
    void Update()
    {
        if(LoadingSuccess==true)
        {
            fTime += Time.deltaTime;
            if (fTime >= 1f)
            {
                LoadingBar.SetActive(false);
                start.SetActive(true);
            }
           
        }
    }
}