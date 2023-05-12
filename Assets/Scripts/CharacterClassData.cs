using UnityEngine;

[CreateAssetMenu(fileName = "CharacterClassData", menuName = "Game/Character Class")]
public class CharacterClassData : ScriptableObject
{
    public string className;
    public int health;
    public int attack;
    public int defense;
}
