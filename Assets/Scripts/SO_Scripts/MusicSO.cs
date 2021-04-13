using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Music Collection", fileName ="Music Collection")]
public class MusicSO : ScriptableObject
{
    [SerializeField] public AudioClip intro;
    [SerializeField] public AudioClip chapter0;
    [SerializeField] public AudioClip chapter1;
    [SerializeField] public AudioClip chapter2;
    [SerializeField] public AudioClip chapter3;
    [SerializeField] public AudioClip chapter4;
    [SerializeField] public AudioClip chapter5;
    [SerializeField] public AudioClip scary;

}
