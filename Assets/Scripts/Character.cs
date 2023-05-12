using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterClassData characterClass;
    public WeaponData weapon;

    private void Start()
    {
        Debug.Log("Class: " + characterClass.className);
        Debug.Log("Health: " + characterClass.health);
        Debug.Log("Attack: " + characterClass.attack);
        Debug.Log("Defense: " + characterClass.defense);

        Debug.Log("Weapon: " + weapon.weaponName);
        Debug.Log("Damage: " + weapon.damage);
        Debug.Log("Attack Speed: " + weapon.attackSpeed);
    }
}
