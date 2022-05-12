using Music_project.code;
using System.Data;

namespace Music_project.NewFolder
{
    public class songMethods
    {
        private DataSet ds = new DataSet("playlist");
        public List<Song> GetAllSongs(string file)
        {
           // DataSet ds = new DataSet("playlist");

            DataTable dtSongs = new DataTable("song");

            DataColumn dcId = new DataColumn("id");
            DataColumn dcArtist = new DataColumn("artist");
            DataColumn dcTitle = new DataColumn("title");
            DataColumn dcYear = new DataColumn("year");
            DataColumn dcGenre = new DataColumn("genre");
            DataColumn dcTime = new DataColumn("time");

            dtSongs.Columns.Add(dcId);
            dtSongs.Columns.Add(dcArtist);
            dtSongs.Columns.Add(dcTitle);
            dtSongs.Columns.Add(dcYear);
            dtSongs.Columns.Add(dcGenre);
            dtSongs.Columns.Add(dcTime);

            ds.Tables.Add(dtSongs);
            try
            {
                 ds.ReadXml(Environment.CurrentDirectory + "/Data/playlist.xml");
            }
            catch
            { }

            List<Song> songsList = new List<Song>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Song x = new Song();
                x.id = dr["id"].ToString();
                x.title = dr["title"].ToString();
                x.artist = dr["artist"].ToString();
                songsList.Add(x);
            }
            //return ds;
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
        public void Save(string file)
        {
            ds.WriteXml(Environment.CurrentDirectory + "/Data/playlist.xml");
        }
        public void AddNewRow(DataRow dr)
        {
            ds.Tables["song"].Rows.Add(dr);
            ds.WriteXml(Environment.CurrentDirectory + "/Data/playlist.xml");
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
    }
}