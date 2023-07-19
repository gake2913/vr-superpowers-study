using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Logger
{

    private static string currentPath;

    public static void CreateLog(string log, object reference = null, bool newFile = false)
    {
        if (currentPath == null || newFile)
        {
            // get new path
            string directory = Application.dataPath + "/logs/";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            currentPath = directory + "log_" + timestamp + ".txt";

            Debug.Log("Creating new log at: " + currentPath);
            
            // create file and write log
            using (StreamWriter sw = File.CreateText(currentPath))
            {
                WriteToStream(log, sw, reference);
            }
        }
        else
        {
            // append to current log file
            using (StreamWriter sw = File.AppendText(currentPath))
            {
                WriteToStream(log, sw, reference);
            }
        }
    }

    private static void WriteToStream(string log, StreamWriter sw, object reference)
    {
        string loggedString = "[" + DateTime.Now.ToString("HH:mm:ss") + "]: ";
        if (reference != null) loggedString += reference.GetType().Name + ": ";
        loggedString += log;

        sw.WriteLine(loggedString);
        Debug.Log("Created Log: \"" + loggedString + "\"");
    }

}
