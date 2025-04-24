# Jimm's Prefs
A custom playerprefs system with a couple extra savable variable types!
![Showcase](https://github.com/user-attachments/assets/3eddf954-6f06-43f9-ab8f-f1106683b52f)

## Documentation
### Storing Values
Jimm's Prefs works exactly like UnityEngine.PlayerPrefs:
```c#
  JimmsPrefs.SetInt("RandomInterger", 1);
  JimmsPrefs.SetString("RandomString", "Hello World!");
  JimmsPrefs.SetFloat("RandomFloat", 1.5f);
```
<br>
However, this system has some extra features! For example, you can now store more variable types directly!<br><br>


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

All of this is done with just 2 scripts!
Also, instead of storing the data in the windows registry, JimmsPrefs stores it in a .json file!

Here's the code that handles the saving:
```c#
public string SaveName = "Jimm's Prefs.json";
void SavePrefs()
{
    // Creating the data and converting it to json.
    JimmsPrefsData data = new JimmsPrefsData(IntPairs, FloatPairs, BoolPairs, StringPairs, Vector2Pairs, Vector3Pairs);
    string jsonData = JsonUtility.ToJson(data, true);

    // Storing the data at Application.persistentDatPAth
    StreamWriter writer = new(Application.persistentDataPath + Path.DirectorySeparatorChar + SaveName, false);
    writer.Write(jsonData);
    writer.Close();
}
```
### Loading Values

Here are the parameters for the GetInt() function.
```c#
JimmsPrefs.GetInt(string key, int DefaultValue); // If nothing is found, the DefaultValue gets returned instead.
```
Here's an example of each value being loaded:
```c#
  JimmsPrefs.GetInt("RandomInterger", 1);
  JimmsPrefs.GetString("RandomString", "Hello World!");
  JimmsPrefs.GetFloat("RandomFloat", 1.5f);

  JimmsPrefs.GetBool("IsTrue", true);
  JimmsPrefs.GetVector2("Position2D", new(0, 5));
  JimmsPrefs.GetVector3("Position3D", new(0, 5, 3));
```
Finally, Default Values are mandatory. 
```c#
    JimmsPrefs.GetInt("RandomInterger"); // -> This will throw an error!
```
