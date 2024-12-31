using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using DG.Tweening;
using System.Runtime.CompilerServices;

public class MenuButtonsManager : MonoBehaviour
{
    public List<GameObject> buttons;

    [Header("Animation")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;

    public Ease BackEase = Ease.OutBack;

    private void Awake()
    {
        HideAllButtons();
        ShowButtons();
    }

    private void HideAllButtons()
    {
        foreach (var b in buttons)
        {
            b.transform.localScale = Vector3.zero;
            b.SetActive(false);
        }
    }

    private void ShowButtons()
    {
        for(int i = 0; i < buttons.Count; i++)
        {
            var b = buttons[i];
            b.SetActive(true);
            b.transform.DOScale(1, duration).SetDelay(i*delay).SetEase(ease);
        }
    }

    public void ExitScenes()
    {
        int _i = -1;

        foreach(var bu in buttons)
        {
            _i++;

            bu.transform.DOScale(0, duration).SetDelay(_i*delay).SetEase(BackEase);
        }
    }
}
