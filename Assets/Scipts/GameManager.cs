using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private string path;

    // Start is called before the first frame update
    void Start()
    {
        path = Path.Combine(Application.persistentDataPath, "stats.csv");
        Debug.Log("GameManager loaded....");

        int x = 10;
        int y = 0;

        int[] list = { 1, 2, 3 };

        
        Debug.Log(path);
        try
        {

            //var text = File.ReadAllLines(path);
            File.AppendAllText(path, $"Started, Aidan, 0, {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r\n");

            

        } catch(FileNotFoundException ex)
        {
            Debug.Log("File not found");

            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            File.WriteAllText(path, $"Started, Aidan, 0, {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r\n");
        }
        catch (System.IndexOutOfRangeException ex)
        {
            Debug.Log("index out of bounds");
        }
        catch (System.Exception ex)
        {
            Debug.Log("something went wrong");
        }

        Debug.Log("GameManager Start() finished");



    }

    // Update is called once per frame
    void Update()
    {
        // simulate the game ending by pressing Escape key
        if (Input.GetKey(KeyCode.Escape))
        {
            File.AppendAllText(path, $"Finished, Aidan, 0, {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r\n");
            Debug.Log("Game Over");
            EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}
