using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;



public static class TextParser
{

    // Reads text files line by line and converts each read line into a
    // string that is then pushbacked into a queue
    public static void ReadFileIntoQueue(string path, ref Queue<DialogueTuple> queue)
    {
        if (!File.Exists(path))
            throw new FileLoadException("Dialogue file (" + path + ") does not exist");

        // Tries to use StreamReader to read the file (catches exceptions if
        // it fails)
        try
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string fileLine;

                // Adds read file line (up to newline) and pushbacks to
                // the queue
                while ((fileLine = reader.ReadLine()) != null)
                    queue.Enqueue( new DialogueTuple( "Fag", ParseInlineSymbols(fileLine) ) );
            }
        }
        catch (IOException e)
        {
            Debug.Log("[TEXT_PARSER] Line could not be read");
            Debug.Log(e.Message);
        }
    }

    private static string ParseInlineSymbols(string line)
    {
        line = line.Replace("<br/>", "\n");
        return line;
    }

}
