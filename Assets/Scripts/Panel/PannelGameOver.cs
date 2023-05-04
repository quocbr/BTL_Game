using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PannelGameOver : MonoBehaviour
{
    [SerializeField] protected Text kill;
    [SerializeField] protected Text time;

    public void SetKill()
    {
        kill.text = GameController.Instance.countEnemyKill.ToString();
    }

    public void SetTime()
    {
        time = Watch.Instance.stopwatchText;
    }

}
