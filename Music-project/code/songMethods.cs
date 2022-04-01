using System.Data;

namespace Music_project.NewFolder
{
    public class songMethods   
    {
        private DataSet ds = new DataSet("playlist");
        public DataSet GetAllSongs(string file)
        {

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
            return ds;
        }   
        public DataRow GetEmptyDataRow()
        {
            DataRow dr = DataSet.Tables["song"].NewRow();
            return dr;
        }
    }
}
