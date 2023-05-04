using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardController : MonoBehaviour
{
    private static CardController _instance;

    public static CardController Instance
    {
        get => _instance;
    }

    [SerializeField] private Card[] AllSkills;
    public Card[] chooseSkill;

    protected void Awake()
    {
        CardController._instance = this;
        if (AllSkills == null)
        {
            AllSkills = Resources.LoadAll<Card>("Skills");
        } 
        chooseSkill = GetRandomElements(3);
    }

    private void OnDisable()
    {
        chooseSkill = GetRandomElements(3);
    }

    private Card[] GetRandomElements(int count)
    {
        Card[] randomElements = new Card[count];
        Card[] copyArray = (Card[]) AllSkills.Clone();

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, copyArray.Length);
            randomElements[i] = copyArray[randomIndex];

            // Loại bỏ phần tử đã chọn để không bị chọn lại
            for (int j = randomIndex; j < copyArray.Length - 1; j++)
            {
                copyArray[j] = copyArray[j + 1];
            }

            System.Array.Resize(ref copyArray, copyArray.Length - 1);
        }

        return randomElements;
    }
}