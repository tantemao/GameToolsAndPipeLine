using UnityEngine;
using UnityEditor;

public class DesignerInterface : MonoBehaviour
{
    public Character character;
    public CharacterClassData[] characterClasses;
    public WeaponData[] weapons;

    private int selectedClassIndex;
    private int selectedWeaponIndex;
    private bool showStats;

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 400, 400));

        GUILayout.Label("Character Class:");
        selectedClassIndex = GUILayout.SelectionGrid(selectedClassIndex, GetClassNames(), 2, GUILayout.Width(200));

        GUILayout.Label("Weapon:");
        selectedWeaponIndex = GUILayout.SelectionGrid(selectedWeaponIndex, GetWeaponNames(), 2, GUILayout.Width(200));

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Apply Changes", GUILayout.Width(120)))
        {
            ApplyChanges();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.EndArea();

        GUILayout.BeginArea(new Rect(Screen.width - 310, 10, 300, 400));

        GUILayout.Label("Show Stats:");
        showStats = GUILayout.Toggle(showStats, "Show");

        if (showStats)
        {
            ShowStats();
        }

        GUILayout.EndArea();
    }

    private string[] GetClassNames()
    {
        string[] classNames = new string[characterClasses.Length];
        for (int i = 0; i < characterClasses.Length; i++)
        {
            classNames[i] = characterClasses[i].className;
        }
        return classNames;
    }

    private string[] GetWeaponNames()
    {
        string[] weaponNames = new string[weapons.Length];
        for (int i = 0; i < weapons.Length; i++)
        {
            weaponNames[i] = weapons[i].weaponName;
        }
        return weaponNames;
    }

    private void ApplyChanges()
    {
        if (selectedClassIndex >= 0 && selectedClassIndex < characterClasses.Length)
        {
            character.characterClass = characterClasses[selectedClassIndex];
        }

        if (selectedWeaponIndex >= 0 && selectedWeaponIndex < weapons.Length)
        {
            character.weapon = weapons[selectedWeaponIndex];
        }
    }

    private void ShowStats()
    {
        GUILayout.Label("Character Stats:");
        GUILayout.BeginHorizontal();
        GUILayout.Label("Health: ", GUILayout.Width(100));
        GUILayout.FlexibleSpace();
        GUILayout.Label(character.characterClass.health.ToString());
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Attack: ", GUILayout.Width(100));
        GUILayout.FlexibleSpace();
        GUILayout.Label(character.characterClass.attack.ToString());
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Defense: ", GUILayout.Width(100));
        GUILayout.FlexibleSpace();
        GUILayout.Label(character.characterClass.defense.ToString());
        GUILayout.EndHorizontal();

        GUILayout.Space(10);
        GUILayout.Label("Weapon Stats:");
        GUILayout.BeginHorizontal();
        GUILayout.Label("Damage: ", GUILayout.Width(100));
        GUILayout.FlexibleSpace();
        GUILayout.Label(character.weapon.damage.ToString());
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Attack Speed: ", GUILayout.Width(100));
        GUILayout.FlexibleSpace();
        GUILayout.Label(character.weapon.attackSpeed.ToString());
        GUILayout.EndHorizontal();
    }
}
