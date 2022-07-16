using Music_project.code;
using Newtonsoft.Json;
using System.Data;

namespace Music_project.NewFolder
{
    public class songMethods
    {
      
        private List<Song> lssongs;
        string xmlfile;
        public songMethods()
        {
            string json = File.ReadAllText(filename);
            lssongs = JsonConvert.DeserializeObject<List<Song>>(json);


            try
            {
                string jsonString = File.ReadAllText(filename);
                songList = JsonConvert.DeserializeObject<List<Song>>(jsonString);
            }
            catch
            {

            }
        }

        //variabelen
        private List<Song> songList = null;
        private string filename = Environment.CurrentDirectory + "\\Data\\playlist.json";



        public List<Song> GetAllSongs()
        {
            return songList;
        }
        public Song getSong(int id)
        {
            foreach(Song song in songList)
            {
                if (song.id == id)
                {
                    return song;
                }
            }
            return null;
        }
     
      
        public void Save()
        {
            string json = JsonConvert.SerializeObject(songList);
            File.WriteAllText(filename, json);

          
        }
        public void AddNewRow(Song s)
        {
            songList.Add(s);
            WriteDataToFile();
        }
        public void DeleteSong(string id, string file)
        {
            songList.Remove(getSong(int.Parse(id)));
            WriteDataToFile();
        }
        public void WriteDataToFile()
        {
            string json = JsonConvert.SerializeObject(songList);
            File.WriteAllText(filename, json);
        }
    }
}