# Jimm's Prefs
A custom playerprefs system with a couple extra savable variables!
![Showcase](https://github.com/user-attachments/assets/3eddf954-6f06-43f9-ab8f-f1106683b52f)

## Documentation
### Storing Values
Jimm's Prefs works exactly like UnityEngine.PlayerPrefs.
```c#
  JimmsPrefs.SetInt("RandomInterger", 1);
  JimmsPrefs.SetString("RandomInterger", "Hello World!");
  JimmsPrefs.SetFloat("RandomFloat", 1.5f);
```
<br>
Despite this, some extra features have been added!
(For example, you can now store more variables directly!)<br>

*No more boolean to int conversion nonsense!*
```c#
  JimmsPrefs.SetBool("IsTrue", true);
```
*You can also store Vector2 & Vector3 positions!*
```c#
  JimmsPrefs.SetVector2("Position2D", new(0, 5));
  JimmsPrefs.SetVector3("Position3D", new(0, 5, 3));
```
<br>
<br>

All of this is done with only 2 scripts!
The most notable difference here is that this system is likely more performant than Unity's simple system (no guarantees though). Also, it's stored in .json format!
```c#
public string SaveName = "Jimm's Prefs.json";
void SavePrefs()
{
    //Creating the data and converting it to json.
    JimmsPrefsData data = new JimmsPrefsData(IntPairs, FloatPairs, BoolPairs, StringPairs, Vector2Pairs, Vector3Pairs);
    string jsonData = JsonUtility.ToJson(data, true);

    //Storing the data at Application.persistentDatPAth
    StreamWriter writer = new(Application.persistentDataPath + Path.DirectorySeparatorChar + SaveName, false);
    writer.Write(jsonData);
    writer.Close();
}
```
### Loading Values

Here's how each value can be loaded:
```c#
JimmsPrefs.GetInt(string key, int DefaultValue);
```
```c#
  JimmsPrefs.GetInt("RandomInterger", 1);
  JimmsPrefs.GetString("RandomInterger", "Hello World!");
  JimmsPrefs.GetFloat("RandomFloat", 1.5f);

  JimmsPrefs.GetBool("IsTrue", true);
  JimmsPrefs.GetVector2("Position2D", new(0, 5));
  JimmsPrefs.GetVector3("Position3D", new(0, 5, 3));
```
The only difference here is that Default Values are mandatory.
```c#
    JimmsPrefs.GetInt("RandomInterger"); //This will throw an error.
```
