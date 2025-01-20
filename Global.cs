using System.Text.Json.Nodes;

namespace Library_Management_System
{
    public static class Global
    {
        public static void Modify_appsettings(string key , string value)
        {
            string json_path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            string json_string = File.ReadAllText(json_path);
            JsonNode json = JsonNode.Parse(json_string);
            if(json!=null)
            {
                json[key] = value;
            }
            File.WriteAllText(json_path, json?.ToJsonString(new System.Text.Json.JsonSerializerOptions { WriteIndented = true }));
        }

        public static string Get_value(string key)
        {
            string json_path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            string json_string = File.ReadAllText(json_path);
            JsonNode json = JsonNode.Parse(json_string);
            return json?[key]?.ToString();
        }

    }
}
