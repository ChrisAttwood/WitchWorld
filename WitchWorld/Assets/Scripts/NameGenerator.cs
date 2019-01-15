using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Globalization;

public static class NameGenerator {

    static string[] fName;
    static string[] surname;

    public static void NameFactory()
    {
        var femaleTextFile = Resources.Load("Text/femaleNames", typeof(TextAsset)) as TextAsset; //C#
        fName = femaleTextFile.text.Split('\n');
        var surnameTextFile = Resources.Load("Text/Surnames", typeof(TextAsset)) as TextAsset; //C#
        surname = surnameTextFile.text.Split('\n');
    }

    public static string GenerateFemaleFirstName()
    {
        string value = Regex.Replace(GetOne(fName).Replace(" ", "").Replace(".", ""), @"[\d-]", string.Empty);
        value = value.ToLower();
        return char.ToUpper(value[0]) + value.Substring(1);
    }

    public static string GenerateSurname()
    {
        string value = Regex.Replace(GetOne(surname).Replace(" ", "").Replace(".", ""), @"[\d-]", string.Empty);
        value = value.ToLower();
        return char.ToUpper(value[0]) + value.Substring(1);
    }

    public static string GetOne(string[] words)
    {
        return words[Random.Range(0, words.Length)];
    }
}
