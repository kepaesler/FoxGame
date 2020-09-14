
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveSystem
{
    public static void SavePlayer(PlayerCurrentData playercurdata)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(playercurdata);
        try
        {
            formatter.Serialize(stream, data);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        finally
        {
            stream.Close();
        }
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.save";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = null;
            try
            {
                data = formatter.Deserialize(stream) as PlayerData;
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
            finally
            {
                stream.Close();
            }

            return data;
        }
        else
        {
            Debug.Log("File not found");
            return null;
        }
    }
}
