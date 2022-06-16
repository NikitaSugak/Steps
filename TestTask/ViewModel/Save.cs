using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows;
using TestTask.Model;

namespace TestTask.ViewModel
{
    internal static class Save
    {
        public static string path;
        public static async void saveInFile(User user)
        {
            string json = getJsonString(user);

            if (path == String.Empty || path == null)
            {
                path = getFileName();
            }
            if (path == String.Empty || path == null)
            {

                MessageBox.Show("User don't save.");
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    await writer.WriteLineAsync(json);
                }
            }
        }

        private static string getJsonString(User user)
        {
            JObject jsonObject = new JObject();
            jsonObject["User"] = user.Name;
            jsonObject["Average Steps"] = user.AverageOfSteps;
            jsonObject["Max Steps"] = user.MaxSteps;
            jsonObject["Min Steps"] = user.MinSteps;

            JObject[] status = new JObject[user.status.Count];

            for (int i = 0; i < user.status.Count; i++)
            {
                status[i] = new JObject();
                status[i]["Day " + (i + 1)] = user.status[i];
            }

            JArray jArrayStatus = new JArray(status);
            jsonObject["Status"] = jArrayStatus;

            JObject[] steps = new JObject[user.steps.Count];

            for (int i = 0; i < user.steps.Count; i++)
            {
                steps[i] = new JObject();
                steps[i]["Steps for " + (i + 1) + " day"] = user.steps[i];
            }

            JArray jArraySteps = new JArray(steps);
            jsonObject["Steps"] = jArraySteps;

            JToken jToken = jsonObject;

            return jToken.ToString();
        }

        public static string getFileName()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.DefaultExt = "json";
            saveFileDialog1.AddExtension = true;

            if ((bool)saveFileDialog1.ShowDialog())
            {
                return saveFileDialog1.FileName;
            }

            return String.Empty;
        }
    }
}
