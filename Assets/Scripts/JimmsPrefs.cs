using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JimmsPrefs : MonoBehaviour
{
    public string SaveName = "Jimm's Prefs.json";
    
    public List<JimmsPrefsData.IntPair> IntPairs = new();
    public List<JimmsPrefsData.FloatPair> FloatPairs = new();
    public List<JimmsPrefsData.BoolPair> BoolPairs = new();
    public List<JimmsPrefsData.StringPair> StringPairs = new();
    public List<Vector2Pair> Vector2Pairs = new();
    public List<Vector3Pair> Vector3Pairs = new();

    //Key Differences between JimmPrefs and JimmPrefsData is that the vectorPairs in JimmPrefs are actual Vector2s.
    public class Vector2Pair
    {
        public string Key;
        public Vector2 Value;
        public Vector2Pair(JimmsPrefsData.Vector2Pair vecPair)
        {
            Key = vecPair.Key;
            Value = new(vecPair.Value[0], vecPair.Value[1]);
        }
        public Vector2Pair(string Key, Vector2 Value)
        {
            this.Key = Key;
            this.Value = Value;
        }
    }
    public class Vector3Pair
    {
        public string Key;
        public Vector3 Value;
        public Vector3Pair(JimmsPrefsData.Vector3Pair vecPair)
        {
            Key = vecPair.Key;
            Value = new(vecPair.Value[0], vecPair.Value[1], vecPair.Value[2]);
        }
        public Vector3Pair(string Key, Vector3 Value)
        {
            this.Key = Key;
            this.Value = Value;
        }
    }
    public static JimmsPrefs instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            if(File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + SaveName))
                LoadPrefs();
        }
        else
            Destroy(this.gameObject);
    }


    public static void SetInt(string key, int value)
    {
        JimmsPrefsData.IntPair pair = instance.IntPairs.Find(a => a.Key == key);
        
        if(pair == null) instance.IntPairs.Add(new() { Key = key, Value = value });
        else pair.Value = value;
        
        instance.SavePrefs();
    }
    public static void SetFloat(string key, float value)
    {
        JimmsPrefsData.FloatPair pair = instance.FloatPairs.Find(a => a.Key == key);
        
        if (pair == null) instance.FloatPairs.Add(new() { Key = key, Value = value });
        else pair.Value = value;
        
        instance.SavePrefs();
    }
    public static void SetBool(string key, bool value)
    {
        JimmsPrefsData.BoolPair pair = instance.BoolPairs.Find(a => a.Key == key);
        
        if (pair == null) instance.BoolPairs.Add(new() { Key = key, Value = value });
        else pair.Value = value;
        
        instance.SavePrefs();
    }
    public static void SetString(string key, string value)
    {
        JimmsPrefsData.StringPair pair = instance.StringPairs.Find(a => a.Key == key);
        
        if (pair == null) instance.StringPairs.Add(new() { Key = key, Value = value });
        else pair.Value = value;

        instance.SavePrefs();
    }
    public static void SetVector2(string key, Vector2 value)
    {
        Vector2Pair pair = instance.Vector2Pairs.Find(a => a.Key == key);
        
        if (pair == null) instance.Vector2Pairs.Add(new(key, value ));
        else pair.Value = value;

        instance.SavePrefs();
    }
    public static void SetVector3(string key, Vector3 value)
    {
        Vector3Pair pair = instance.Vector3Pairs.Find(a => a.Key == key);
        
        if (pair == null) instance.Vector3Pairs.Add(new(key, value));
        else pair.Value = value;

        instance.SavePrefs();
    }

    public static int GetInt(string key, int DefaultValue)
    {
        JimmsPrefsData.IntPair pair = instance.IntPairs.Find(a => a.Key == key);
        if (pair != null) return pair.Value;
        return DefaultValue;
    }
    public static float GetFloat(string key, float DefaultValue)
    {
        JimmsPrefsData.FloatPair pair = instance.FloatPairs.Find(a => a.Key == key);
        if (pair != null) return pair.Value;
        return DefaultValue;
    }
    public static bool GetBool(string key, bool DefaultValue)
    {
        JimmsPrefsData.BoolPair pair = instance.BoolPairs.Find(a => a.Key == key);
        if (pair != null) return pair.Value;
        return DefaultValue;
    }
    public static string GetString(string key, string DefaultValue)
    {
        JimmsPrefsData.StringPair pair = instance.StringPairs.Find(a => a.Key == key);
        if (pair != null) return pair.Value;
        return DefaultValue;
    }
    public static Vector2 GetVector2(string key, Vector2 DefaultValue)
    {
        Vector2Pair pair = instance.Vector2Pairs.Find(a => a.Key == key);
        if (pair != null) return pair.Value;
        return DefaultValue;
    }
    public static Vector3 GetVector3(string key, Vector3 DefaultValue)
    {
        Vector3Pair pair = instance.Vector3Pairs.Find(a => a.Key == key);
        if (pair != null) return pair.Value;
        return DefaultValue;
    }

    void SavePrefs()
    {
        JimmsPrefsData data = new JimmsPrefsData(IntPairs, FloatPairs, BoolPairs, StringPairs, Vector2Pairs, Vector3Pairs);
        string jsonData = JsonUtility.ToJson(data, true);
        StreamWriter writer = new(Application.persistentDataPath + Path.DirectorySeparatorChar + SaveName, false);
        writer.Write(jsonData);
        writer.Close();
    }
    void LoadPrefs()
    {
        StreamReader reader = new(Application.persistentDataPath + Path.DirectorySeparatorChar + SaveName);
        string jsonData = reader.ReadToEnd();
        reader.Close();
        JimmsPrefsData data = JsonUtility.FromJson<JimmsPrefsData>(jsonData);

        IntPairs = data.data.intPairs;
        FloatPairs = data.data.floatPairs;
        BoolPairs = data.data.boolPairs;
        StringPairs = data.data.stringPairs;
        Vector2Pairs = Vector2sToPrefs(data.data.vector2Pairs);
        Vector3Pairs = Vector3sToPrefs(data.data.vector3Pairs);

    }
    List<Vector2Pair> Vector2sToPrefs(List<JimmsPrefsData.Vector2Pair> vec2pairs)
    {
        List<Vector2Pair> pairs = new();
        for (int i = 0; i < vec2pairs.Count; i++)
        {
            pairs.Add(new(vec2pairs[i]));
        }
        return pairs;
    }
    List<Vector3Pair> Vector3sToPrefs(List<JimmsPrefsData.Vector3Pair> vec3pairs)
    {
        List<Vector3Pair> pairs = new();
        for (int i = 0; i < vec3pairs.Count; i++)
        {
            pairs.Add(new(vec3pairs[i]));
        }
        return pairs;
    }
}