using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card",menuName = "Card")]
public class Card : ScriptableObject
{
     public new string name;
     public string description;

    public Sprite artWork;
    public int attack;
     public int health;
    public float range;
     public float speed;
    public int shield;
    public float speedAttack;

}
