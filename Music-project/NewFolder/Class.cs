using System.Data;

namespace Music_project.NewFolder
{
    public class songMethods
    {
        public DataSet GetAllSongs(string file)
        {
            DataSet ds = new DataSet("playlist");

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

            ds.ReadXml(Environment.CurrentDirectory + file);

            return ds;
        }   

    }
}
