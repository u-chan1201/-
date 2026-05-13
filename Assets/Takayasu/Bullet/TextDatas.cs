using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextDatas", menuName = "Scriptable Objects/TextDatas")]
public class TextDatas : ScriptableObject
{
    [Header("テキストと音声の内容は順番が一緒になるようにしてほしいです")]
    public List<string> text;
    public List<string> soundName;
}
