using Music_project.code;
using Newtonsoft.Json;
using System.Data;

namespace Music_project.NewFolder
{
    public class songMethods
    {
        private DataSet dsSongs;
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


        private DataSet ds = new DataSet("playlist");
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
        public DataRow GetEmptyDataRow()
        {
            DataRow dr = ds.Tables["song"].NewRow();
            return dr;
        }
        public DataRow getDataRow(string id)
        {
            DataRow[] drSongs = ds.Tables["song"].Select("id = '" + id + "'");
            if (drSongs != null && drSongs.Length > 0)
            {
                return drSongs[0];
            }
            return null;    
        }
        public void Save()
        {
            string json = JsonConvert.SerializeObject(songList);
            File.WriteAllText(filename, json);

            ds.WriteXml(Environment.CurrentDirectory + "/Data/playlist.xml");
        }
        public void AddNewRow(Song dr)
        {
            //ds.Tables["song"].Rows.Add(dr);
            //ds.WriteXml(Environment.CurrentDirectory + "/Data/playlist.xml");
        }
        public void DeleteSong(string id, string file)
        {
            DataRow[] drSongs = ds.Tables["song"].Select("id = '" + id + "'");
            if (drSongs != null && drSongs.Length > 0)
            {
                drSongs[0].Delete();
                ds.WriteXml(Environment.CurrentDirectory + "/Data/playlist.xml");
            }
        }
        public void EditSong(string id, DataRow editedRow, string file)
        {
            DataRow drSongs = getDataRow(id);

                drSongs["id"] = editedRow["id"];
                drSongs["artist"] = editedRow["artist"];
                drSongs["title"] = editedRow["title"];
                drSongs["year"] = editedRow["year"];
   
            ds.WriteXml(Environment.CurrentDirectory + "/Data/playlist.xml");
            
        }
        public void WriteDataToFile()
        {
            string json = JsonConvert.SerializeObject(songList);
            File.WriteAllText(filename, json);
        }
        public void CreateSong(Song song)
        {

        }
    }
}