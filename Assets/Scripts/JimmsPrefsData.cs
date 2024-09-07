using System;
using System.Collections;
using System.Collections.Generic;

public class JimmsPrefsData
{
    //Defining the data type pairs
    [Serializable]
    public class IntPair
    {
        public string Key;
        public int Value = 0;
    }
    [Serializable]
    public class FloatPair
    {
        public string Key;
        public float Value = 0;
    }
    [Serializable]
    public class BoolPair
    {
        public string Key;
        public bool Value = false;
    }
    [Serializable]
    public class StringPair
    {
        public string Key;
        public string Value = "";
    }
    [Serializable]
    public class Vector2Pair
    {
        public string Key;
        public float[] Value = { 0, 0 };
        public Vector2Pair(JimmsPrefs.Vector2Pair vec3Pair)
        {
            Key = vec3Pair.Key;
            Value[0] = vec3Pair.Value.x;
            Value[1] = vec3Pair.Value.y;
        }
    }
    [Serializable]
    public class Vector3Pair
    {
        public string Key;
        public float[] Value = { 0, 0, 0 };
        public Vector3Pair(JimmsPrefs.Vector3Pair vec3Pair)
        {
            Key = vec3Pair.Key;
            Value[0] = vec3Pair.Value.x;
            Value[1] = vec3Pair.Value.y;
            Value[2] = vec3Pair.Value.z;
        }
    }


    //Defining the data type lists. They have to be wrapped in a class because JsonUtility works like that -\_(:/)_/-
    [Serializable]
    public class DataList
    {
        public List<IntPair> intPairs = new();
        public List<FloatPair> floatPairs = new();
        public List<BoolPair> boolPairs = new();
        public List<StringPair> stringPairs = new();
        public List<Vector2Pair> vector2Pairs = new();
        public List<Vector3Pair> vector3Pairs = new();
        public DataList(List<IntPair> intPairs, List<FloatPair> floatPairs, List<BoolPair> boolPairs, List<StringPair> stringPairs, 
            List<JimmsPrefs.Vector2Pair> vector2Pairs, List<JimmsPrefs.Vector3Pair> vector3Pairs)
        {
            this.intPairs = intPairs;
            this.floatPairs = floatPairs;
            this.boolPairs = boolPairs;
            this.stringPairs = stringPairs;

            this.vector2Pairs.Clear();
            this.vector3Pairs.Clear();
            for (int i = 0; i < vector2Pairs.Count; i++)
            {
                this.vector2Pairs.Add(new(vector2Pairs[i]));
            }
            for (int i = 0; i < vector3Pairs.Count; i++)
            {
                this.vector3Pairs.Add(new(vector3Pairs[i]));
            }
        }   
    }
    public DataList data;

    public JimmsPrefsData(List<IntPair> intPairs, List<FloatPair> floatPairs, List<BoolPair> boolPairs, List<StringPair> stringPairs, 
        List<JimmsPrefs.Vector2Pair> vector2Pairs, List<JimmsPrefs.Vector3Pair> vector3Pairs)
    {
        data = new(intPairs, floatPairs, boolPairs, stringPairs, vector2Pairs, vector3Pairs);
    }
}