using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBox : MonoBehaviour
{
    [SerializeField]
    private Text textLevel;

    [SerializeField]
    private Image fillBg;

    [SerializeField]
    private Color color;

    [SerializeField]
    private GameObject effectPrefab;

    public int level;
    public float currentEXP;
    private Coroutine routine;

    private void OnEnable()
    {
        fillBg.color = color;;
        level = 0;
        //currentEXP = 0;
        fillBg.fillAmount = currentEXP;
    }

    public void UpdateProgress(float EXPAmount, float duration = 0.1f) 
    {
        if(routine != null)
        {
            StopCoroutine(routine);
        }
        float target = currentEXP + EXPAmount;

        routine = StartCoroutine(FillRoutine(target, duration));
    }

    private IEnumerator FillRoutine(float target, float duration)
    {
        float time = 0;
        float tempAmount = currentEXP;
        float diff = target - tempAmount;
        currentEXP = target;

        while(time < duration)
        {
            time += Time.deltaTime;
            float percent = time / duration;
            fillBg.fillAmount = tempAmount + diff * percent;

            yield return null;
        }

        if(currentEXP >= 1)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        if(effectPrefab != null)
        {
            GameObject GO = Instantiate(effectPrefab, gameObject.transform);
            Destroy(GO, 3f);
        }

        UpdateLevel(level + 1);
        UpdateProgress(-1f, 0.2f);
    }

    private void UpdateLevel(int level)
    {
        this.level = level;
        textLevel.text = "Level " + this.level.ToString();
    }

}
